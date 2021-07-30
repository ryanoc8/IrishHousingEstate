﻿using System;
using System.Collections.Generic;
using System.Text;

namespace IrishHousingEstate.ModelApp.Response
{
    public class HouseDataResponse
    {
        public IEnumerable<HouseDataModel> HouseDataModel { get; set; }
    }

    public class HouseDataModel
    {
        public int Id { get; set; }
        public int AreaGroupEffect { get; set; }
        public string County { get; set; }
        public int CountyEffect { get; set; }
        public int PropertySizeSquareMeters { get; set; }
        public int PropertySizeEffect { get; set; }
        public string YearBuild { get; set; }
        public string BerRating { get; set; }
        public int NumberOfBedrooms { get; set; }
    }
}
