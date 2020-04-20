using System;
using System.Collections.Generic;
using System.Linq;
using ColdFrame.Models;

namespace ColdFrame.Data
{
    public class SamplePlants
    {
        public static int NumberOfPlants = 1;
        
        private static IList<IList<string>> _plantData = new List<IList<string>>
        {
            new List<string>{"4", "Squash", "Squash is a genus of herbaceous vines that have large edible orange flowers that mature into gourds or cucurbits. Squash are commonly divided into two main groups: summer and winter.", 
                "True", "False", "2020-03-01", "2020-05-30", "2020-06-01", "2020-09-30","https://s3.amazonaws.com/openfarm-project/production/media/pictures/attachments/54b4a9046130650002010000.jpg?1421125890"}
        };

        public static IEnumerable<Plant> GetPlants()
        {
            return Enumerable.Range(0, NumberOfPlants).Select(CreateRandomPlant);
            
        }
        
        private static Plant CreateRandomPlant(int index)
        {
            return new Plant
            {
                PlantId = Convert.ToInt32(_plantData[index][0]),
                PlantName = _plantData[index][1],
                Description = _plantData[index][2],
                Vegetable = Convert.ToBoolean(_plantData[index][3]),
                Fruit = Convert.ToBoolean(_plantData[index][4]),
                SowFrom = Convert.ToDateTime(_plantData[index][5]),
                SowTo = Convert.ToDateTime(_plantData[index][6]),
                HarvestFrom = Convert.ToDateTime(_plantData[index][7]),
                HarvestTo = Convert.ToDateTime(_plantData[index][8]),
                ImageUrl = _plantData[index][9]
            };
            
            
        }
    }
}