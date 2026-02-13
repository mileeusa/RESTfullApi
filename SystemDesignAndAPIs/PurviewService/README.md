graph TD
    %% Data Sources
    subgraph Sources ["1. Discover (Data Sources)"]
        direction LR
        M365[M365: SharePoint, Teams, OneDrive]
        AZ[Azure: Blob, SQL, CosmosDB]
    end

    %% Ingestion Layer
    subgraph Ingest ["2. Extract (Ingestion)"]
        direction LR
        Webhooks[Graph API Webhooks]
        EventGrid[Azure Event Grid]
        Extract[Azure Functions: Text Extraction]
    end

    %% Processing Layer
    subgraph Process ["3. Classify (AI Engine)"]
        direction TB
        Regex[L1: Regex/SSN Patterns] --> Fingerprint[L2: Document Fingerprinting]
        Fingerprint --> OpenAI[L3: Azure OpenAI Contextual Analysis]
    end

    %% Storage & Logic
    subgraph Catalog ["4. Map (Metadata Catalog)"]
        Cosmos[(Cosmos DB: Global Data Map)]
    end

    %% Action Layer
    subgraph Actions ["5. Enforce (Compliance)"]
        direction LR
        MIP[Apply Sensitivity Labels]
        DLP[Block External Sharing]
        RBAC[Azure RBAC Restriction]
    end

    %% Reporting
    subgraph Audit ["6. Audit (Reporting)"]
        direction LR
        Logs[Azure Monitor / Log Analytics]
        Dash[Executive Compliance Dashboard]
    end

    %% Main Vertical Connections
    Sources --> Ingest
    Ingest --> Process
    Process --> Catalog
    Catalog --> Actions
    Actions --> Audit

    %% Styling
    style Sources fill:#f9f,stroke:#333,stroke-width:2px
    style Process fill:#bbf,stroke:#333,stroke-width:2px
    style Actions fill:#bfb,stroke:#333,stroke-width:2px
    style Cosmos fill:#fff4dd,stroke:#d4a017,stroke-width:2px