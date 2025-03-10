﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using OpenTelemetry.Metrics;

namespace Azure.Monitor.OpenTelemetry.Exporter.Models
{
    internal partial class MetricsData
    {
        public MetricsData(int version, Metric metric, MetricPoint metricPoint) : base(version)
        {
            if (metric == null)
            {
                throw new ArgumentNullException(nameof(metric));
            }

            IList<MetricDataPoint> metricDataPoints = new List<MetricDataPoint>();
            MetricDataPoint metricDataPoint = new MetricDataPoint(metric, metricPoint);
            metricDataPoints.Add(metricDataPoint);
            Metrics = metricDataPoints;
            Properties = new ChangeTrackingDictionary<string, string>();
            foreach (var tag in metricPoint.Tags)
            {
                if (tag.Key.Length <= SchemaConstants.MetricsData_Properties_MaxKeyLength && tag.Value != null)
                {
                    // Note: if Key exceeds MaxLength or if Value is null, the entire KVP will be dropped.

                    Properties.Add(new KeyValuePair<string, string>(tag.Key, tag.Value.ToString().Truncate(SchemaConstants.MetricsData_Properties_MaxValueLength)));
                }
            }
        }
    }
}
