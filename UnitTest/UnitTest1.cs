using System;
using Xunit;
using Ikst.GlobalHotkey;

namespace UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

            using (GlobalHotkey gh = new GlobalHotkey())
            {
                int id = gh.Regist(6, 80, () => Console.WriteLine(1));
                //gh.UnRegist(id);

                //id = gh.Regist(6, 81, () => Console.WriteLine(2));

            }

            
        }
    }
}
