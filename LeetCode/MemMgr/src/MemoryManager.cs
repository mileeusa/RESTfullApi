using NUnit.Framework;
using System;
using System.Drawing;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace MemMgr.src
{
    //
    // I'd like to design a memory management system with the following interfaces:
    // bool initialize(int sizeInBytes); // initialize (1000) memory addressable 0 to 999
    // int allocate(int sizeInBytes);    // success allocate (10) => 50 (location in memory, return -1 if no memory to allocate
    // bool deallocate(int location);    // success deallocate (50) => true, failure deallocate(50) => false
    //
    // Please help to think about the solutions, and tell me the pro and con. how about defragmentation
    //
    // This implementation prioritizes correctness and clarity. It handles fragmentation safely through coalescing and
    // mirrors real-world allocator behavior.
    //
    // 1. Clarify assumptions (important at senior level)
    // Before coding, state assumptions:
    //   - Memory is a contiguous byte array[0 … size - 1]
    //   - allocate(size) must return a contiguous block
    //   - deallocate(location) frees the block that starts at location
    //   - No partial free; size is determined internally
    //   - Single-threaded(unless stated otherwise)
    //   - No pointer arithmetic needed, just offsets
    // This shows maturity immediately.
    //
    // 2. Core problems to solve
    //   - Tracking free memory
    //   Tracking allocated blocks
    //   Handling fragmentation
    //   Allocation strategy
    //   Defragmentation(optional / advanced)
    //
    public class MemoryManager
    {
        private class Block
        {
            public int Start;
            public int Size;

            public Block(int start, int size)
            {
                Start = start;
                Size = size;
            }
        }

        private readonly List<Block> _freeList = [];
        private readonly Dictionary<int, int> _allocated = []; // key: start location, value: size
        private bool _initialized;

        public bool Initialize(int sizeInBytes)
        {
            if (sizeInBytes <= 0) return false;

            _freeList.Clear();
            _allocated.Clear();

            _freeList.Add(new Block(0, sizeInBytes));
            _initialized = true;

            return true;
        }

        public int Allocate(int sizeInBytes)
        {
            if (!_initialized || sizeInBytes <= 0)
                return -1;

            for (int i = 0; i < _freeList.Count; i++)
            {
                var block = _freeList[i];

                if (block.Size > sizeInBytes)
                {
                    int allocatedStart = block.Start;

                    block.Start += sizeInBytes;
                    block.Size -= sizeInBytes;

                    if (block.Size == 0)
                    {
                        _freeList.RemoveAt(i);
                    }

                    _allocated[allocatedStart] = sizeInBytes;

                    return allocatedStart;
                }
            }

            return -1;
        }

        public bool Deallocate(int location)
        {
            if (!_initialized || !_allocated.TryGetValue(location, out var size))
            {
                return false;
            }

            _allocated.Remove(location);

            // insert the free block
            _freeList.Add(new Block(location, size));

            _freeList.Sort((a, b) => a.Start.CompareTo(b.Start));

            MergeFreeBlocks();

            return true;
        }

        // we cannot do any defragment, only coalesce or merge the free blocks
        private void MergeFreeBlocks()
        {
            for (int i = 0; i < _freeList.Count - 1; )
            {
                var current = _freeList[i];
                var next    = _freeList[i + 1];

                if (current.Start + current.Size == next.Start)
                {
                    // merge
                    current.Size += next.Size;
                    _freeList.RemoveAt(i + 1);
                }
                else
                {
                    i++;
                }
            }
        }
    }
}
