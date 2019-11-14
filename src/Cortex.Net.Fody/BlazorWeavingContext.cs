﻿// <copyright file="BlazorWeavingContext.cs" company="Jan-Willem Spuij">
// Copyright 2019 Jan-Willem Spuij
//
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy,
// modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom
// the Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
// COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
// ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// </copyright>

namespace Cortex.Net.Fody
{
    using global::Fody;
    using Mono.Cecil;

    /// <summary>
    /// Context class for Weaving.
    /// </summary>
    public class BlazorWeavingContext : WeavingContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlazorWeavingContext"/> class.
        /// </summary>
        /// <param name="moduleWeaver">Moduleweaver to use.</param>
        public BlazorWeavingContext(CortexWeaver moduleWeaver)
            : base(moduleWeaver)
        {
            this.CortexNetBlazorObserverAttribute = this.TryResolveFromReference(moduleWeaver, "Cortex.Net.Blazor.ObserverAttribute", "Cortex.Net.Blazor");
            this.CortexNetBlazorObserverObject = this.TryResolveFromReference(moduleWeaver, "Cortex.Net.Blazor.ObserverObject", "Cortex.Net.Blazor");
        }

        /// <summary>
        /// Gets type reference to Cortex.Net.Blazor.ObserverAttribute.
        /// </summary>
        internal TypeReference CortexNetBlazorObserverAttribute { get; private set; }

        /// <summary>
        /// Gets type reference to Cortex.Net.Blazor.ObserverObject.
        /// </summary>
        internal TypeReference CortexNetBlazorObserverObject { get; private set; }
    }
}
