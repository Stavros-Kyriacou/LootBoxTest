using System;

namespace LootBoxTest
{
    class Program
    {
        static int[] rewardWeights = { 10, 5, 10, 10 };
        static int[] componentWeights = { 10, 10, 10, 10 };
        static int[] rewards = { 2, 3, 4, 5, 6 };
        static int[] tier1ComponentWeights = { 300, 5, 0, 0, 0, 0, 0, 0, 0, 0 };
        static int[] tier2ComponentWeights = { 300, 100, 20, 5, 0, 0, 0, 0, 0, 0 };
        static int[] tier3ComponentWeights = { 500, 400, 300, 80, 30, 0, 0, 0, 0, 0 };
        static int[] tier4ComponentWeights = { 0, 0, 300, 300, 300, 300, 300, 15, 0, 0 };
        static int[] tier5ComponentWeights = { 0, 0, 400, 400, 350, 300, 300, 15, 1, 0 };

        #region Component Tier Rolls
        //tier 1 lootbox
        //t1   300
        //t2   5

        //tier 2 lootbox
        //t1   300
        //t2   100
        //t3   20
        //t4   5

        //tier 3 lootbox
        //t1   500
        //t2   400
        //t3   300
        //t4   80
        //t5   30

        //tier 4 lootbox
        //t3   300
        //t4   300
        //t5   300
        //t6   300
        //t7   300
        //t8   15

        //tier 5 lootbox
        //t3   400
        //t4   400
        //t5   350
        //t6   300
        //t7   300
        //t8   15
        //t9   1
        #endregion

        static void Main(string[] args)
        {
            //different tiers of lootboxes 1-5
            //tier 1 lowest rarity, tier 5 highest
            //each tier has a guaranteed number of rewards. eg tier 1 has 2 rewards

            //scrap, gems, components, boosts

            while (true)
            {
                Console.WriteLine("Open a lootbox!");
                Console.Write("Enter a tier(1-5) of lootbox to open: ");
                int tier = int.Parse(Console.ReadLine());
                if (tier < 1 || tier > 5) break;
                OpenLootBox(tier);
            }
        }

        static void OpenLootBox(int tier)
        {
            Console.WriteLine("Your rewards are...");
            for (int i = 0; i < rewards[tier - 1]; i++)
            {
                int rewardType = RollWeights(rewardWeights);
                switch (rewardType)
                {
                    case 0:
                        RollScrap(tier);
                        break;
                    case 1:
                        RollGems(tier);
                        break;
                    case 2:
                        RollComponent(tier);
                        break;
                    case 3:
                        RollBoost(tier);
                        break;
                    default:
                        break;
                }

            }
            Console.WriteLine();
        }
        static void RollComponent(int tier)
        {
            int componentType = RollWeights(componentWeights);
            int componentTier = 0;

            switch (tier)
            {
                case 1:
                    componentTier = RollWeights(tier1ComponentWeights);
                    break;
                case 2:
                    componentTier = RollWeights(tier2ComponentWeights);
                    break;
                case 3:
                    componentTier = RollWeights(tier3ComponentWeights);
                    break;
                case 4:
                    componentTier = RollWeights(tier4ComponentWeights);
                    break;
                case 5:
                    componentTier = RollWeights(tier5ComponentWeights);
                    break;
                default:
                    break;
            }
            componentTier += 1;
            
            switch (componentType)
            {
                case 0:
                    Console.WriteLine("You rolled a tier {0} CPU", componentTier);
                    break;
                case 1:
                    Console.WriteLine("You rolled a tier {0} GPU", componentTier);
                    break;
                case 2:
                    Console.WriteLine("You rolled a tier {0} HDD", componentTier);
                    break;
                case 3:
                    Console.WriteLine("You rolled a tier {0} RAM", componentTier);
                    break;
                default:
                    break;
            }

        }
        static int RollWeights(int[] weights)
        {
            Random random = new Random();
            int total = 0;
            int index = 0;

            foreach (var weight in weights)
            {
                total += weight;
            }

            int roll = random.Next(0, total);

            for (int i = 0; i < weights.Length; i++)
            {
                if (roll <= weights[i])
                {
                    index = i;
                    break;
                }
                else
                {
                    roll -= weights[i];
                }
            }
            return index;
        }
        static void RollBoost(int tier)
        {

            Console.WriteLine("You rolled a boost");




        }
        static void RollScrap(int tier)
        {
            Random random = new Random();
            int scrap = 0;

            switch (tier)
            {
                case 1:
                    scrap = random.Next(5, 20);
                    break;
                case 2:
                    scrap = random.Next(25, 40);
                    break;
                case 3:
                    scrap = random.Next(45, 60);
                    break;
                case 4:
                    scrap = random.Next(65, 80);
                    break;
                case 5:
                    scrap = random.Next(85, 100);
                    break;
                default:
                    break;
            }
            Console.WriteLine("You rolled {0} scrap", scrap);
        }
        static void RollGems(int tier)
        {
            Random random = new Random();
            int gems = 0;

            switch (tier)
            {
                case 1:
                    gems = random.Next(1, 10);
                    break;
                case 2:
                    gems = random.Next(10, 20);
                    break;
                case 3:
                    gems = random.Next(20, 30);
                    break;
                case 4:
                    gems = random.Next(30, 40);
                    break;
                case 5:
                    gems = random.Next(40, 50);
                    break;
                default:
                    break;
            }
            Console.WriteLine("You rolled {0} gems", gems);
        }
    }
}
