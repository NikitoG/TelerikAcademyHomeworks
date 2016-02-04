using InformationalSite.Models;

namespace InformationalSite.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<InformationalSite.Data.ApplicationDbContext>
    {
        private const string Source =
              @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam vitae facilisis est. Sed purus tellus, efficitur a fringilla nec, efficitur sed felis. Phasellus id varius ex, a scelerisque ante. Nunc enim justo, sagittis eu massa sit amet, dapibus consectetur dui. Nulla lobortis, mi non dapibus laoreet, mi lacus bibendum dolor, egestas vehicula erat metus in ligula. Quisque tincidunt tincidunt lacus ut aliquet. Vivamus gravida a neque at vulputate. Fusce mauris ligula, vehicula non feugiat id, elementum et sem. Proin nulla massa, porttitor quis ultricies ac, fringilla vitae quam. Pellentesque non finibus diam. Aliquam in mauris aliquet, interdum diam mollis, suscipit eros. Ut arcu ex, posuere ut tellus a, maximus aliquet erat.

Mauris elementum nec justo id sagittis.Vivamus laoreet, neque id vestibulum facilisis, nisi est ultrices dolor, non consequat ligula neque in dolor.Nam nec tincidunt ex, nec sodales lorem.Curabitur sit amet tincidunt dolor.Quisque tincidunt laoreet gravida. Etiam quis metus ut nisl lobortis tincidunt.Duis sodales eget justo vitae laoreet. Nunc nec bibendum magna. Mauris ullamcorper dolor purus, sed efficitur orci posuere sit amet. Suspendisse potenti.

Nullam ullamcorper bibendum ipsum, sit amet consequat tellus eleifend vel. Donec aliquam sed arcu non pellentesque. Integer bibendum enim quis orci pretium scelerisque.Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos.Suspendisse sed libero ex. Duis a convallis elit, ac consequat elit.Suspendisse ultrices, nisi vel ultrices feugiat, libero ligula tempus nulla, vitae pharetra sem diam vitae felis. Fusce et lorem pellentesque, blandit mi in, rutrum nulla. Mauris sit amet quam et nisi auctor varius eget ut mi.Quisque ut neque ligula. Ut vitae nisi at sapien commodo pretium.Pellentesque gravida pharetra massa id cursus. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.Donec at leo vitae eros aliquet tincidunt vitae accumsan erat.

Mauris vitae condimentum libero. Donec luctus ultricies sodales. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.Cras gravida turpis in quam convallis, quis dictum risus faucibus. Fusce rhoncus pretium lectus vel semper. Duis arcu urna, tempor sed aliquam sit amet, viverra in dolor.Cras ex mi, gravida vitae erat gravida, porta luctus leo.Quisque sagittis ornare fringilla. Morbi pulvinar sapien in tempor rutrum. Duis tincidunt, lacus et hendrerit tincidunt, ex diam viverra risus, ac varius sem velit sit amet felis.In maximus justo lorem, vitae tincidunt nisl hendrerit vel.Etiam cursus suscipit nunc in posuere.Sed vel laoreet magna. Nullam consectetur lectus mi, posuere ultricies nisi iaculis sed.Sed et massa eu ante sagittis condimentum.Pellentesque nec felis in augue ullamcorper rutrum a quis massa.

Etiam quis ullamcorper libero. Ut posuere viverra lacus, ac eleifend purus auctor id.Integer condimentum, nisl sit amet tristique mollis, ipsum justo imperdiet purus, mattis egestas lectus tortor at urna. Donec volutpat, nisi at sagittis rutrum, nisi lectus venenatis metus, non blandit magna urna vel mi. Nunc tincidunt, magna eget sollicitudin varius, dui diam sollicitudin justo, convallis fermentum arcu mauris ut sem. Mauris tempus lacus sit amet ipsum efficitur, quis placerat nisl blandit. In et tortor turpis. Nulla sagittis vehicula justo, sit amet imperdiet ante tincidunt at. Donec placerat eget orci eget hendrerit. Aenean pharetra non urna nec mollis. Vestibulum malesuada nisl orci, eu molestie leo commodo eget.Aenean at quam sed nunc eleifend hendrerit.Aliquam molestie efficitur libero sed dignissim. Sed finibus, quam eu lobortis dignissim, metus felis bibendum augue, nec aliquam mauris nisi sit amet leo.Nulla mattis maximus nisi in hendrerit.

Nunc imperdiet semper nisi vel dapibus. Aliquam eu enim nunc. Nunc pulvinar lacus tempor orci accumsan, vel pellentesque eros egestas. Mauris finibus, nunc vel pretium viverra, justo ex dictum velit, vel ullamcorper sapien nulla ut est. Etiam at fermentum purus. Praesent vel euismod metus, in sollicitudin velit. Suspendisse ac placerat sapien, sit amet efficitur erat. Nam et ligula neque. Aenean viverra, orci ut iaculis tincidunt, sem libero imperdiet arcu, nec finibus orci nunc vitae lectus. Sed sit amet quam vel lorem placerat blandit ut sed sem.Duis arcu tellus, molestie ac mollis quis, egestas eu enim.

Curabitur vel velit id urna semper porta sit amet vitae nisi.Pellentesque fermentum quis purus sit amet pulvinar.Curabitur vehicula vitae nulla a lacinia. In a egestas nulla. Cras elementum pulvinar est, ut facilisis eros pulvinar fringilla.Donec sit amet condimentum mauris.Curabitur bibendum felis at facilisis hendrerit. Vivamus sed augue vitae odio viverra aliquet ut vel urna. Nulla in tempus dolor, in vulputate neque. Curabitur augue tortor, consectetur ac quam vitae, placerat sollicitudin dui.Phasellus tristique aliquet augue non dignissim. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas.Vivamus in mattis tortor, ac blandit nibh.

In eu odio turpis. Nam eget ligula enim. Nunc feugiat tempus ante faucibus rutrum. Aliquam nibh lorem, vulputate non accumsan vitae, tempus vel orci.Sed varius, elit vel congue ornare, sem libero tristique dui, vitae tristique ipsum eros nec est. Cras tellus mauris, ultricies ac massa a, tincidunt rutrum justo.Donec rutrum nibh vel mi placerat, non iaculis dolor euismod. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.Sed tempor porttitor orci vel faucibus. Quisque diam est, dapibus eget nulla at, tincidunt dapibus purus.Phasellus tincidunt lorem quis ex rhoncus rutrum.Integer suscipit faucibus ex id vestibulum. Sed quis dolor vitae augue consectetur facilisis.

Vestibulum accumsan dui sapien, consectetur condimentum urna luctus eu.Duis ullamcorper augue ut lectus lacinia, eu pulvinar eros posuere. Vestibulum gravida lacus velit, ut consequat mauris elementum quis.Vivamus ullamcorper enim ac sem semper pulvinar.Sed nec mi eu tellus scelerisque molestie sit amet sed dolor.Vivamus et tincidunt sem. Nam maximus sapien nulla, ut dapibus nunc placerat vel.In hac habitasse platea dictumst.Pellentesque sagittis pulvinar vulputate. Curabitur egestas tempor nisl, vel mollis dolor lacinia eget.Phasellus lacinia, dui gravida convallis porttitor, purus augue venenatis dolor, et feugiat lorem nisl at magna. In sit amet magna eros.

Vestibulum mollis dignissim sem sed vulputate. Aenean quam magna, lacinia sed tellus ac, mollis mattis diam.Nullam luctus est est, vitae posuere libero aliquet ac.Nam sed ante at tortor aliquet venenatis at non sapien. Donec ut arcu nec odio pharetra accumsan ac ac ante. Curabitur ut accumsan purus. Etiam dui justo, consequat accumsan rutrum id, dictum eget diam.Praesent vitae aliquet dolor, non pharetra massa.Donec posuere nibh quis diam maximus, ut aliquet massa iaculis. Morbi id tristique justo. Suspendisse magna massa, finibus et scelerisque vitae, malesuada nec velit.Nam quis hendrerit velit.";

        private Random rand = new Random();

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(InformationalSite.Data.ApplicationDbContext context)
        {
            if (context.Articles.Count() != 0)
            {
                return;
            }

            for (int i = 0; i < 100; i++)
            {
                var newArticle = new Article
                {
                    Header = Source.Substring(rand.Next(0, 7000), rand.Next(10, 20)),
                    Content = Source.Substring(rand.Next(0, 3500), rand.Next(100, 2000)),
                    Rating = rand.Next(0, 51)
                };

                context.Articles.Add(newArticle);
            }

            context.SaveChanges();
        }
    }
}
