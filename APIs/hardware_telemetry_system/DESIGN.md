# Datacenter Hardware Telemetry System Design

## 1. Problem Overview
Design a system to **collect, process, and analyze CPU and Fan Speed metrics** from **6M+ datacenter servers** for **reporting, alerting, and analytics**.

The system must operate at **global scale**, support **near-real-time alerts**, and provide **long-term historical insights**, while remaining **cost-efficient, reliable, and extensible**.

---

## 2. Requirements

### Functional Requirements
- Collect CPU utilization, temperature, and fan speed from each server
- Support near-real-time alerting (seconds to 1 minute)
- Provide dashboards and reports
- Enable historical analysis (weeks to years)
- Support heterogeneous hardware and evolving schemas
- Multi-region deployment

### Non-Functional Requirements
- Scale to millions of devices and billions of events/day
- High availability and fault tolerance
- Low ingestion latency
- Backpressure handling
- Secure communication and access control
- Cost-efficient at scale

---

## 3. Scale Estimation

### Assumptions
- 6M servers
- Metrics collected every 10 seconds
- ~200 bytes per metric record (compressed)

### Calculations
- Events per second: 6M × 0.1 = **600K events/sec**
- Ingest bandwidth: 600K × 200B ≈ **120 MB/sec**
- Daily volume ≈ **10 TB/day**

This scale requires **streaming ingestion and distributed storage**.

---

## 4. High-Level Architecture

```
+-------------------+
| Server Agents     |
+---------+---------+
          |
          v
+-------------------+
| Regional Ingest   |
| Gateways          |
+---------+---------+
          |
          v
+-------------------+
| Message Broker    |
| (Kafka/EventHub) |
+----+------+-------+
     |      |
     |      +------------------+
     v                         v
+----------+           +------------------+
| Stream   |           | Hot Storage      |
| Process  |           | (Time-Series DB) |
+----+-----+
     |
     v
+------------------+
| Alerting Engine  |
+------------------+

     |
     v
+------------------+
| Cold Storage     |
| (Data Lake)     |
+------------------+
```

---

## 5. Server Agent Design

### Responsibilities
- Collect CPU metrics via OS counters
- Collect fan speed via BMC/IPMI
- Batch and compress metrics
- Local disk-backed buffering
- Retry with exponential backoff
- Rate limiting and fail-open behavior

### Data Format
- Protobuf or Avro
- Schema-driven with versioning

```protobuf
message HardwareMetric {
  string device_id;
  string region;
  int64 timestamp;
  map<string, double> metrics;
}
```

---

## 6. Regional Ingestion Layer

### Purpose
- Reduce latency
- Isolate failures
- Avoid cross-region traffic

### Characteristics
- Stateless services
- Anycast/DNS-based routing
- Authentication via mTLS
- Validation and normalization
- Horizontal autoscaling

---

## 7. Message Broker Layer

### Choice
- Apache Kafka or Azure Event Hubs

### Responsibilities
- Absorb ingestion spikes
- Decouple producers and consumers
- Support replay and multiple downstream pipelines

### Partitioning Strategy
- Partition key: device_id
- ~200–500 partitions for current scale and growth
- Replication factor ≥ 3

---

## 8. Stream Processing (Hot Path)

### Use Cases
- Threshold-based alerts
- Rolling averages
- Anomaly detection
- Aggregation by rack, cluster, or region

### Technology
- Apache Flink or Spark Structured Streaming

### Example Logic
```
IF avg(cpu_usage over 60s) > 90%
AND fan_speed < expected_threshold
THEN trigger alert
```

---

## 9. Alerting System

### Features
- Rule-based evaluation
- Alert deduplication
- Alert suppression and throttling
- Routing to on-call systems

### Reliability
- Durable alert storage
- Idempotent alert delivery
- At-least-once semantics

---

## 10. Storage Architecture

### Hot Storage (Recent Data)
- Time-series database (Azure Data Explorer, InfluxDB)
- Retention: 7–30 days
- Optimized for low-latency queries and dashboards

### Cold Storage (Long-Term)
- Data lake (Parquet on Blob/S3)
- Partitioned by region/date/hour
- Retention: months to years
- Used for analytics, ML, and compliance

---

## 11. Querying & Reporting

### Dashboards
- Pre-aggregated metrics
- Cached queries
- Per-region and per-cluster views

### Analytics
- Spark/Synapse
- SQL over Parquet
- Batch and ad-hoc analysis

---

## 12. Reliability & Failure Handling

### Agent
- Disk buffering
- Drop stale data
- Health monitoring

### Ingestion
- Stateless design
- Autoscaling
- Backpressure signaling

### Broker & Processing
- Replication and checkpointing
- Replay on failure
- No data loss on consumer restart

---

## 13. Security

- mTLS between agents and ingestion
- Device identity via certificates
- RBAC for data access
- Encryption in transit and at rest
- PII-free telemetry

---

## 14. Cost Optimizations

- Metric sampling for low-priority signals
- Edge aggregation at agent
- Tiered storage
- Compression and batching

---

## 15. Future Extensions

- Add GPU, power, disk, and network metrics
- Predictive failure detection using ML
- Automated remediation workflows
- Cross-region correlation and root-cause analysis

---

## 16. Interview Evaluation Focus

Interviewers typically look for:
- Correct scale estimation
- Clear separation of concerns
- Failure handling and resilience
- Schema evolution strategy
- Hot vs cold path design
- Thoughtful tradeoff discussion

