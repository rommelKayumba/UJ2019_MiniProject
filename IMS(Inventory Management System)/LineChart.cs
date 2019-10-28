using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LineChart
/// </summary>
public class LineChart
{

    public List<SeriesItems> series;
    public string[] fetcheData
        ;
    public LineChart(List<SeriesItems> iSeries, string[] iFecthes)
    {
        //
        // TODO: Add constructor logic here
        //
        series = iSeries;
        fetcheData = iFecthes;

    }

    public LineChart()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}