using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using App.Model;

namespace App.Data.SampleData
{
    public class AppDatabaseInitializer : 
        //CreateDatabaseIfNotExists<CodeCamperDbContext>      // when model is stable
        DropCreateDatabaseIfModelChanges<AppDbContext> // when iterating
    {

        protected override void Seed(AppDbContext context)
        {
            InitBaseValues(context);
            InitGames(context);
            InitUsers(context);
        }

        protected Random Rand = new Random();

        private void InitBaseValues(AppDbContext context)
        {
            //Consoles
            context.Consoles.Add(new App.Model.Console { ConsoleId = 1, Title = "Xbox 360", Abbrev = "360" });
            context.Consoles.Add(new App.Model.Console { ConsoleId = 2, Title = "PlayStation 3", Abbrev = "PS3" });
            context.Consoles.Add(new App.Model.Console { ConsoleId = 3, Title = "Wii", Abbrev = "Wii" });
            context.Consoles.Add(new App.Model.Console { ConsoleId = 4, Title = "WiiU", Abbrev = "WiiU" });
            context.Consoles.Add(new App.Model.Console { ConsoleId = 5, Title = "PC", Abbrev = "PC" });
            context.Consoles.Add(new App.Model.Console { ConsoleId = 6, Title = "3DS", Abbrev = "3DS" });
            context.Consoles.Add(new App.Model.Console { ConsoleId = 7, Title = "PS Vita", Abbrev = "Vita" });

            context.SaveChanges();


            //Vendors
            context.Vendors.Add(new Vendor { Name = "Amazon", Abbrev = "AZ", WebsiteUrl = "http://www.amazon.com" });
            context.Vendors.Add(new Vendor { Name = "Gamestop", Abbrev = "GS", WebsiteUrl = "http://www.gamestop.com" });
            context.Vendors.Add(new Vendor { Name = "Best Buy", Abbrev = "BB", WebsiteUrl = "http://www.bestbuy.com" });
            context.Vendors.Add(new Vendor { Name = "Toys R Us", Abbrev = "TRU", WebsiteUrl = "http://www.toysrus.com" });
            context.Vendors.Add(new Vendor { Name = "Steam", Abbrev = "ST", WebsiteUrl = "http://www.steampowered.com" });
            context.Vendors.Add(new Vendor { Name = "Newegg", Abbrev = "EGG", WebsiteUrl = "http://www.newegg.com" });
            context.Vendors.Add(new Vendor { Name = "Origin", Abbrev = "ORG", WebsiteUrl = "http://www.origin.com" });
            context.Vendors.Add(new Vendor { Name = "Target", Abbrev = "TG", WebsiteUrl = "http://www.target.com" });

            context.SaveChanges();
        }

        private void InitGames(AppDbContext context)
        {

            context.Games.Add(new Game { GameId = 2, Title = "Castlevania: Lords of Shadow 2", ReleaseDate = DateTime.Parse("3/5/14"), Description = "Castlevania: Lords of Shadow 2 is an Action-Adventure game which serves as the final chapter in Konami's Lords of Shadow reboot of the classic Castlevania game series. The game revisits the actions of one-time member of the 'Brotherhood of Light,' Gabriel Belmont, in the previous game installment and details the consequences of those actions in the face of the rise of a familiar, ancient evil that only he has the ability to combat.", Consoles = new List<App.Model.Console> { context.Consoles.FirstOrDefault(c => c.ConsoleId == 1), context.Consoles.FirstOrDefault(c => c.ConsoleId == 2) } });
            context.Games.Add(new Game { GameId = 3, Title = "Metal Gear Rising: Revengeance", Description = "METAL GEAR RISING: REVENGEANCE takes the renowned METAL GEAR franchise into exciting new territory by focusing on delivering an all-new action experience unlike anything that has come before. Combining world-class development teams at Kojima Productions and PlatinumGames, METAL GEAR RISING: REVENGEANCE brings two of the world's most respected teams together with a common goal of providing players with a fresh synergetic experience that combines the best elements of pure action and epic storytelling, all within the expansive MG universe. The game introduces Raiden as the central character; a child soldier transformed into a half-man, half-machine cyborg ninja, equipped with a high-frequency katana blade and a soul fueled by revenge.", ReleaseDate = DateTime.Parse("2/19/14"), Consoles = new List<App.Model.Console> { context.Consoles.FirstOrDefault(c => c.ConsoleId == 1), context.Consoles.FirstOrDefault(c => c.ConsoleId == 2) } });
            context.Games.Add(new Game { GameId = 4, Title = "DMC: Devil May Cry", ReleaseDate = DateTime.Parse("1/15/14"), Description = "Dante is caught between two worlds — the world of humans, and the darker, evil world of demons. The child of an angel and a demon, he knows he's neither human nor demon — he's an outcast. After a lifetime of being tormented by demons, Dante is a man with no respect for authority or society in general. Join Dante on his mission through Limbo.", Consoles = new List<App.Model.Console> { context.Consoles.FirstOrDefault(c => c.ConsoleId == 1), context.Consoles.FirstOrDefault(c => c.ConsoleId == 2) } });
            context.Games.Add(new Game { GameId = 5, Title = "Anarchy Reigns", ReleaseDate = DateTime.Parse("1/8/14"), Description = "Take on the roles of imaginative human and cyborg characters in over-the-top close combat in Anarchy Reigns. Master each of the eight character's unique style, weapon and signature kill move to become the ultimate survivor. Take cover as Action Trigger Events provide a constantly changing gameplay environment with real-time events such as The Black Hole, a plane crash and blitz bombing. Challenge your friends in multiplayer modes, including Battle Royale, Deathmatch and Survival mode. Play as Jack or Leo in the single-player Campaign mode in the ultimate survival of the fittest. Immerse yourself in the violence and combat of the post-apocalyptic future where Anarchy Reigns. ", Consoles = new List<App.Model.Console> { context.Consoles.FirstOrDefault(c => c.ConsoleId == 1), context.Consoles.FirstOrDefault(c => c.ConsoleId == 2) } });
            context.Games.Add(new Game { GameId = 6, Title = "God of War: Ascension", ReleaseDate = DateTime.Parse("3/12/14"), Description = "God of War: Ascension is a Hack N' Slash Action game and PlayStation 3 exclusive that serves as a prequel to the popular God of War video game series. The game is the seventh release in the series, and reveals the details of Kratos' initial betrayal by Ares while human, and the source of his rage. Game features include: eight-player online multiplayer support, new combat and puzzle mechanics, HD video output and bluetooth headset support, and new enemies to battle.", Consoles = new List<App.Model.Console> { context.Consoles.FirstOrDefault(c => c.ConsoleId == 2) } });
            context.Games.Add(new Game { GameId = 7, Title = "Gears of War Judgement", ReleaseDate = DateTime.Parse("3/19/14"), Description = "Gears of War: Judgment delivers the most intense and challenging 'Gears' game yet, with a campaign that takes you back to the immediate aftermath of Emergence Day – the defining event of the 'Gears of War' universe – for the very first time, and tests your mettle in highly–competitive new multiplayer modes.", Consoles = new List<App.Model.Console> { context.Consoles.FirstOrDefault(c => c.ConsoleId == 1), context.Consoles.FirstOrDefault(c => c.ConsoleId == 2) } });
            context.Games.Add(new Game { GameId = 8, Title = "Dead Space 3", ReleaseDate = DateTime.Parse("2/5/14"), Description = "Dead Space 3 is a Third-Person Shooter with Survival-Horror gameplay elements that challenges players to work singly, or with a friend to stop the viral/monster Necromorph outbreak. The game features the return of franchise hero, Isaac Clarke and the necessity of his weapons making abilities and precision skill in using them against in order to defeat enemies. Other game features include, drop-in/out co-op support, the additional character John Carver, evolved Necromorph enemies, a new cover system, side missions, and more.", Consoles = new List<App.Model.Console> { context.Consoles.FirstOrDefault(c => c.ConsoleId == 1), context.Consoles.FirstOrDefault(c => c.ConsoleId == 2) } });
            context.Games.Add(new Game { GameId = 9, Title = "Metro Last Light", ReleaseDate = DateTime.Parse("4/1/14"), Description = "Metro: Last Light is a First-Person Shooter (FPS), with Survival-Horror gameplay elements that challenges players to survive the dangers of post-apocalyptic Moscow. The game is a sequel to the 2010 release, Metro 2033, and features the same main character in a brand-new story. Features include: a more immersive gameworld with varied environments, an exotic arsenal of handmade weaponry, the ability to visibly track your character's ammo and air reserves, a variety of enemy types, and stunning lighting and physics sets.", Consoles = new List<App.Model.Console> { context.Consoles.FirstOrDefault(c => c.ConsoleId == 1), context.Consoles.FirstOrDefault(c => c.ConsoleId == 2) } });
            context.Games.Add(new Game { GameId = 10, Title = "Aliens Colonial Marines", ReleaseDate = DateTime.Parse("2/12/14"), Description = "Aliens: Colonial Marines is a First-Person Shooter set in the Alien movie franchise universe in which the player takes on the role of a member of a squad of colonial marines sent to the planet LV-426. The game is designed as a true sequel to the 1986 movie, Aliens, done in video game format, and features iconic locations, weapons and alien varieties from Aliens and other movies in the series. Additional features include: four-player co-op functionality, a new alien type, and customizable weapons.", Consoles = new List<App.Model.Console> { context.Consoles.FirstOrDefault(c => c.ConsoleId == 1), context.Consoles.FirstOrDefault(c => c.ConsoleId == 2) } });
            context.Games.Add(new Game { GameId = 11, Title = "Bioshock Infinite", ReleaseDate = DateTime.Parse("3/26/14"), Description = "BioShock Infinite is a single player First-Person Shooter, and the third game in the critically and popularly acclaimed BioShock Series. The events of BioShock Infinite are set prior to those of earlier games in the series and unrelated. Yet although unrelated, the action in the game contains a familiar flavor and flare, with a combination of human and mechanized opposition, a variety of physical and personal biological weapons, and a distinctive storyline and setting. Additional features include, the brand-new hero Booker DeWitt, the aerial city of Columbia, the vigors/nostrums biological abilities system, and a variety of strategies to use against foes.", Consoles = new List<App.Model.Console> { context.Consoles.FirstOrDefault(c => c.ConsoleId == 1), context.Consoles.FirstOrDefault(c => c.ConsoleId == 2) } });
            context.Games.Add(new Game { GameId = 12, Title = "Injustice: Gods Among Us", ReleaseDate = DateTime.Parse("4/16/14"), Description = "", Consoles = new List<App.Model.Console> { context.Consoles.FirstOrDefault(c => c.ConsoleId == 1), context.Consoles.FirstOrDefault(c => c.ConsoleId == 2) } });
            context.Games.Add(new Game { GameId = 13, Title = "The Walking Dead", ReleaseDate = DateTime.Parse("6/1/14"), Description = "", Consoles = new List<App.Model.Console> { context.Consoles.FirstOrDefault(c => c.ConsoleId == 1), context.Consoles.FirstOrDefault(c => c.ConsoleId == 2) } });
            context.Games.Add(new Game { GameId = 14, Title = "Dead Island: Riptide", ReleaseDate = DateTime.Parse("4/23/14"), Description = "", Consoles = new List<App.Model.Console> { context.Consoles.FirstOrDefault(c => c.ConsoleId == 1), context.Consoles.FirstOrDefault(c => c.ConsoleId == 2), context.Consoles.FirstOrDefault(c => c.ConsoleId == 5) } });
            context.Games.Add(new Game { GameId = 15, Title = "South Park: The Stick of Truth", ReleaseDate = DateTime.Parse("5/1/14"), Description = "", Consoles = new List<App.Model.Console> { context.Consoles.FirstOrDefault(c => c.ConsoleId == 1), context.Consoles.FirstOrDefault(c => c.ConsoleId == 2) } });
            context.Games.Add(new Game { GameId = 16, Title = "Deadpool", ReleaseDate = DateTime.Parse("5/1/14"), Description = "", Consoles = new List<App.Model.Console> { context.Consoles.FirstOrDefault(c => c.ConsoleId == 1), context.Consoles.FirstOrDefault(c => c.ConsoleId == 2) } });
            context.Games.Add(new Game { GameId = 17, Title = "Grand Theft Auto V", ReleaseDate = DateTime.Parse("4/1/14"), Description = "", Consoles = new List<App.Model.Console> { context.Consoles.FirstOrDefault(c => c.ConsoleId == 1), context.Consoles.FirstOrDefault(c => c.ConsoleId == 2) } });
            context.Games.Add(new Game { GameId = 18, Title = "Tomb Raider", ReleaseDate = DateTime.Parse("3/5/14"), Description = "Tomb Raider is an Action-Adventure game that introduces players to the origin of one of the most identifiable video games icons of all-time, Lara Croft. The game features a blend of survival, stealth, melee and ranged combat, and exploration gameplay as a young Lara Croft is forced to push herself past her know limits to survive and unravel the dark history of a forgotten island. In the process she will unlock the adventurer within her. Additional game features include: weapons both familiar and new, upgradable items, a variety of play environments, and human and animal enemies.", Consoles = new List<App.Model.Console> { context.Consoles.FirstOrDefault(c => c.ConsoleId == 1), context.Consoles.FirstOrDefault(c => c.ConsoleId == 2) } });
            context.Games.Add(new Game { GameId = 19, Title = "The Last of Us", ReleaseDate = DateTime.Parse("5/7/14"), Description = "", Consoles = new List<App.Model.Console> { context.Consoles.FirstOrDefault(c => c.ConsoleId == 1), context.Consoles.FirstOrDefault(c => c.ConsoleId == 2) } });
            context.Games.Add(new Game { GameId = 20, Title = "Crysis 3", ReleaseDate = DateTime.Parse("2/26/14"), Description = "Crysis 3 is a First-Person Shooter (FPS) set within a frightening future New York City. The game is a sequel to the 2011 release, Crysis 2, continuing an unfolding adventure revolving around the symbiotic relationship between the wearer of the game's iconic nanosuit, the current protagonist, and the memories of an earlier protagonist stored within the suit. Game features include sandbox shooter gameplay that allows players to choose their path, an upgradable nanosuit, expanded multiplayer options, an explosive arsenal of weapons, and improved graphics provided by the CryENGINE game engine.", Consoles = new List<App.Model.Console> { context.Consoles.FirstOrDefault(c => c.ConsoleId == 1), context.Consoles.FirstOrDefault(c => c.ConsoleId == 2), context.Consoles.FirstOrDefault(c => c.ConsoleId == 5) } });
            context.Games.Add(new Game { GameId = 21, Title = "Beyond Two Souls", ReleaseDate = DateTime.Parse("6/1/14"), Description = "", Consoles = new List<App.Model.Console> { context.Consoles.FirstOrDefault(c => c.ConsoleId == 1), context.Consoles.FirstOrDefault(c => c.ConsoleId == 2) } });
            context.Games.Add(new Game { GameId = 22, Title = "Hitman HD Trilogy", ReleaseDate = DateTime.Parse("6/1/14"), Description = "", Consoles = new List<App.Model.Console> { context.Consoles.FirstOrDefault(c => c.ConsoleId == 1), context.Consoles.FirstOrDefault(c => c.ConsoleId == 2) } });
            context.Games.Add(new Game { GameId = 23, Title = "Tiger Woods PGA Tour 14", ReleaseDate = DateTime.Parse("6/1/14"), Description = "", Consoles = new List<App.Model.Console> { context.Consoles.FirstOrDefault(c => c.ConsoleId == 1), context.Consoles.FirstOrDefault(c => c.ConsoleId == 2) } });
            context.Games.Add(new Game { GameId = 24, Title = "Remember Me", ReleaseDate = DateTime.Parse("6/1/14"), Description = "", Consoles = new List<App.Model.Console> { context.Consoles.FirstOrDefault(c => c.ConsoleId == 1), context.Consoles.FirstOrDefault(c => c.ConsoleId == 2) } });
            context.Games.Add(new Game { GameId = 25, Title = "Grid 2", ReleaseDate = DateTime.Parse("6/1/14"), Description = "", Consoles = new List<App.Model.Console> { context.Consoles.FirstOrDefault(c => c.ConsoleId == 1), context.Consoles.FirstOrDefault(c => c.ConsoleId == 2) } });
            context.Games.Add(new Game { GameId = 26, Title = "Sniper Ghost Warrior 2", ReleaseDate = DateTime.Parse("6/1/14"), Description = "", Consoles = new List<App.Model.Console> { context.Consoles.FirstOrDefault(c => c.ConsoleId == 1), context.Consoles.FirstOrDefault(c => c.ConsoleId == 2) } });
            context.Games.Add(new Game { GameId = 27, Title = "Castlevania Lords of Shadow: Mirror of Fate", ReleaseDate = DateTime.Parse("6/1/14"), Description = "", Consoles = new List<App.Model.Console> { context.Consoles.FirstOrDefault(c => c.ConsoleId == 1), context.Consoles.FirstOrDefault(c => c.ConsoleId == 2) } });
            context.Games.Add(new Game { GameId = 28, Title = "Brothers in Arms: Furious 4", ReleaseDate = DateTime.Parse("6/1/14"), Description = "", Consoles = new List<App.Model.Console> { context.Consoles.FirstOrDefault(c => c.ConsoleId == 1), context.Consoles.FirstOrDefault(c => c.ConsoleId == 2) } });
            context.Games.Add(new Game { GameId = 29, Title = "Sly Cooper: Thieves in Time", ReleaseDate = DateTime.Parse("6/1/14"), Description = "", Consoles = new List<App.Model.Console> { context.Consoles.FirstOrDefault(c => c.ConsoleId == 1), context.Consoles.FirstOrDefault(c => c.ConsoleId == 2) } });
            context.Games.Add(new Game { GameId = 30, Title = "Naruto Ultimate Ninja Storm 3", ReleaseDate = DateTime.Parse("6/1/14"), Description = "", Consoles = new List<App.Model.Console> { context.Consoles.FirstOrDefault(c => c.ConsoleId == 1), context.Consoles.FirstOrDefault(c => c.ConsoleId == 2) } });
            context.Games.Add(new Game { GameId = 31, Title = "StarCraft II: Heart of the Swarm", ReleaseDate = DateTime.Parse("6/1/14"), Description = "", Consoles = new List<App.Model.Console> { context.Consoles.FirstOrDefault(c => c.ConsoleId == 5) } });
            context.Games.Add(new Game { GameId = 1, Title = "Splinter Cell Blacklist", ReleaseDate = DateTime.Parse("4/1/14"), Description = "Tom Clancy's Splinter Cell Blacklist is a third-person oriented Action-Adventure Stealth game, which represents the seventh installment in the best-selling Splinter Cell series. The game is focused around the return of Sam Fisher, serving as the leader of a new, more clandestine and untainted Echelon unit, and the unit's task to stop a countdown of terrorists events aimed at American assets around the world. Game features include multiplayer and co-op game support, the fluid tag-based 'Killing in Motion' game mechanic, the option to complete missions by stealth, and optional voice based Microsoft Kinect sensor support.", Consoles = new List<App.Model.Console> { context.Consoles.FirstOrDefault(c => c.ConsoleId == 1), context.Consoles.FirstOrDefault(c => c.ConsoleId == 2) } });

            context.SaveChanges();
        }

        private void InitUsers(AppDbContext context)
        {
            var added = context.Users.Add(new User
            {
                Username = "user1",
                RegisteredTimestamp = DateTime.Now,
                EmailAddress = "user01@gmail.com",
                LastLoginTimestamp = DateTime.Now,
                LastViewedActivityFeed = DateTime.Now,
                IsActive = true,
                Avatar = "https://si0.twimg.com/profile_images/3048143198/cc362ea218cef25d0bb6c57a61abf648_bigger.jpeg",
                GettinLists = new List<Gettinlist>
                {
                    new Gettinlist { GameId = context.Games.SingleOrDefault(g => g.Title == "Metal Gear Rising: Revengeance").GameId, ConsoleId = 1, VendorId = 1, AddedTimestamp = DateTime.Now },
                    new Gettinlist { GameId = context.Games.SingleOrDefault(g => g.Title == "DMC: Devil May Cry").GameId, ConsoleId = 1, VendorId = 1, AddedTimestamp = DateTime.Now },
                    new Gettinlist { GameId = context.Games.SingleOrDefault(g => g.Title == "Aliens Colonial Marines").GameId, ConsoleId = 1, VendorId = 1, AddedTimestamp = DateTime.Now }
                }
            });

            added = context.Users.Add(new User
            {
                Username = "user2",
                RegisteredTimestamp = DateTime.Now,
                EmailAddress = "user02@gmail.com",
                LastLoginTimestamp = DateTime.Now,
                LastViewedActivityFeed = DateTime.Now,
                IsActive = true,
                Avatar = "https://si0.twimg.com/profile_images/2798133043/3194c570ae364abe0c02bc377b2e57d2_bigger.jpeg",
                GettinLists = new List<Gettinlist>
                {
                    new Gettinlist { GameId = context.Games.SingleOrDefault(g => g.Title == "Dead Space 3").GameId, ConsoleId = 1, VendorId = 1, AddedTimestamp = DateTime.Now },
                    new Gettinlist { GameId = context.Games.SingleOrDefault(g => g.Title == "Metal Gear Rising: Revengeance").GameId, ConsoleId = 1, VendorId = 1, AddedTimestamp = DateTime.Now }
                }
            });

            added = context.Users.Add(new User
            {
                Username = "user3",
                RegisteredTimestamp = DateTime.Now,
                EmailAddress = "user03@gmail.com",
                LastLoginTimestamp = DateTime.Now,
                LastViewedActivityFeed = DateTime.Now,
                IsActive = true,
                Avatar = "https://si0.twimg.com/profile_images/3042911026/f8265ccff3ef4bdd1958428a9e5662fc_bigger.png",
                GettinLists = new List<Gettinlist>
                {
                    new Gettinlist { GameId = context.Games.SingleOrDefault(g => g.Title == "Dead Space 3").GameId, ConsoleId = 1, VendorId = 1, AddedTimestamp = DateTime.Now },
                }
            });

            context.SaveChanges();
        }
    }
}