using System;
using System.Collections.Generic;
using System.Linq;
using ColdFrame.Models;

namespace ColdFrame.Data
{
    public class SamplePlants
    {
        public static int NumberOfPlants = 4;
        
        private static IList<IList<string>> _plantData = new List<IList<string>>
        {
            new List<string>{"1", "Tomato", "The tomato is the fruit of the tomato plant, a member of the Nightshade family (Solanaceae). The fruit grows on a sprawling vine that often needs to be supported by a cane to keep it upright.",
                "true", "false", "2020-04-20 14:32:54.000000", "2020-06-30 14:33:59.000000", "2020-04-20 14:34:03.000000", "2020-04-20 14:32:08.000000", "https://s3.amazonaws.com/openfarm-project/production/media/pictures/attachments/5dc3618ef2c1020004f936e4.jpg?1573085580"},
            new List<string>{"2", "Broccoli", "Broccoli has large flower heads known as crowns that are green to blue-green in color, grouped tightly together atop a thick stem, and surrounded by leaves.", "true", "false", "2020-01-01 15:47:00.000000", "2020-02-01 15:47:16.000000", "2020-05-01 15:47:33.000000", "2020-06-01 15:47:46.000000",
                "https://s3.amazonaws.com/openfarm-project/production/media/pictures/attachments/54b4b5ea61306500020b0000.jpg?1421129190"},
            new List<string>{"3", "Carrots", "The carrot is a root vegetable. It is usually orange in color, but some cultivars are purple, black, red, white, and yellow. The most commonly eaten part of the plant is the taproot, but the greens are sometimes eaten as well.",
                "true", "false", "2020-03-01 19:30:23.000000", "2020-07-31 19:31:39.000000", "2020-06-01 19:32:39.000000", "2020-10-30 19:32:48.000000", "https://s3.amazonaws.com/openfarm-project/production/media/pictures/attachments/58c312395865650004000000.jpg?1489179191"},
            new List<string>{"4", "Squash", "Squash is a genus of herbaceous vines that have large edible orange flowers that mature into gourds or cucurbits. Squash are commonly divided into two main groups: summer and winter.", 
                "true", "false", "2020-03-01", "2020-05-30", "2020-06-01", "2020-09-30","https://s3.amazonaws.com/openfarm-project/production/media/pictures/attachments/54b4a9046130650002010000.jpg?1421125890"}
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