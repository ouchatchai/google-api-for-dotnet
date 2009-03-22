﻿/**
 * DeserializeException.cs
 *
 * Copyright (C) 2008,  iron9light
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

using System;
using System.Runtime.Serialization;

namespace Google.API
{
    [Serializable]
    internal class DeserializeException : GoogleAPIException
    {
        public DeserializeException(Type objectType, string objectString)
        {
            ObjectType = objectType;
            ObjectString = objectString;
        }

        public DeserializeException(Type objectType, string objectString, Exception innerException)
            : base(null, innerException)
        {
            ObjectType = objectType;
            ObjectString = objectString;
        }

        public Type ObjectType { get; private set; }

        public string ObjectString { get; private set; }

        public override string Message
        {
            get
            {
                return string.Format("Deserialize Failed.{0}Type:{1}{0}String:{2}",
                                     Environment.NewLine,
                                     ObjectType,
                                     ObjectString);
            }
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("ObjectType", ObjectType);
            info.AddValue("ObjectString", ObjectString);
        }
    }
}