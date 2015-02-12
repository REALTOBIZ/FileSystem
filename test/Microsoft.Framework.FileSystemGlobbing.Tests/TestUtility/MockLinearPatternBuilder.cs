﻿// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Framework.FileSystemGlobbing.Internal;

namespace Microsoft.Framework.FileSystemGlobbing.Tests.PatternContexts
{
    internal class MockLinearPatternBuilder
    {
        private List<IPathSegment> _segments;

        public static MockLinearPatternBuilder New()
        {
            return new MockLinearPatternBuilder();
        }

        private MockLinearPatternBuilder()
        {
            _segments = new List<IPathSegment>();
        }

        public MockLinearPatternBuilder Add(string value)
        {
            _segments.Add(new MockNonRecursivePathSegment(value));

            return this;
        }

        public MockLinearPatternBuilder Add(string[] values)
        {
            _segments.AddRange(values.Select(v => new MockNonRecursivePathSegment(v)));

            return this;
        }

        public ILinearPattern Build()
        {
            return new MockLinearPattern(_segments);
        }

        class MockLinearPattern : ILinearPattern
        {
            public MockLinearPattern(List<IPathSegment> segments)
            {
                Segments = segments;
            }

            public IList<IPathSegment> Segments { get; }

            public IPatternContext CreatePatternContextForExclude()
            {
                throw new NotImplementedException();
            }

            public IPatternContext CreatePatternContextForInclude()
            {
                throw new NotImplementedException();
            }
        }
    }
}