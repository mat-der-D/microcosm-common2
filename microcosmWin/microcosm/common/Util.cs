﻿using microcosm.Planet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microcosm.common
{
    public class Util
    {
        public static string root()
        {
            string dir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\microcosm";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            return dir;
        }

        /// <summary>
        /// wpfからuwpへ変換時、奇妙な現象が発生
        /// AppData/LocalとPackages/.../Localを見比べている
        /// どっちもない場合、PackagesがBaseとなる
        /// Packageのみにある場合、Packagesが
        /// Appのみにある場合、AppDataが
        /// 両方ある場合、AppDataがベースとなる
        /// </summary>
        /// <returns></returns>
        public static string root2()
        {
            string dir1 = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\microcosm";
            if (Directory.Exists(dir1))
            {
                using (StreamWriter sw = new StreamWriter(Util.root() + @"\log.txt", true, Encoding.UTF8))
                {
                    sw.WriteLine("directory exists.");
                }
            }
            string dir2 = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Packages\30056ogatism.49446E90E6664_mccaxa6e50ygw\LocalCache\Local\microcosm";
            return dir2;
            /*
            string dir1 = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\microcosm";
            if (Directory.Exists(dir1))
            {
                return dir1;
            }
            */
        }
        
        public static bool isNoDisp(PlanetData p)
        {
            if (!p.isDisp) return true;
            return false;
        }

        public static string getPlanetDegreeTxt(PlanetData p)
        {
            return ((int)(p.absolute_position % 30)).ToString("00");
        }

        public static Dictionary<EShortCut, string> createShortCut()
        {
            Dictionary<EShortCut, string> shortCut = new Dictionary<EShortCut, string>();
            shortCut.Add(EShortCut.Noop, "未設定");
            shortCut.Add(EShortCut.ChagngeSetting0, "設定0に切り替える");
            shortCut.Add(EShortCut.ChagngeSetting1, "設定1に切り替える");
            shortCut.Add(EShortCut.ChagngeSetting2, "設定2に切り替える");
            shortCut.Add(EShortCut.ChagngeSetting3, "設定3に切り替える");
            shortCut.Add(EShortCut.ChagngeSetting4, "設定4に切り替える");
            shortCut.Add(EShortCut.ChagngeSetting5, "設定5に切り替える");
            shortCut.Add(EShortCut.ChagngeSetting6, "設定6に切り替える");
            shortCut.Add(EShortCut.ChagngeSetting7, "設定7に切り替える");
            shortCut.Add(EShortCut.ChagngeSetting8, "設定8に切り替える");
            shortCut.Add(EShortCut.ChagngeSetting9, "設定9に切り替える");
            shortCut.Add(EShortCut.Ring1U1, "1重円(User1)を表示");
            shortCut.Add(EShortCut.Ring1U2, "1重円(User2)を表示");
            shortCut.Add(EShortCut.Ring1E1, "1重円(Event1)を表示");
            shortCut.Add(EShortCut.Ring1E2, "1重円(Event2)を表示");
            shortCut.Add(EShortCut.Ring1Current, "1重円(現在時刻)を表示");
            shortCut.Add(EShortCut.Ring2UU, "2重円(User-User)を表示");
            shortCut.Add(EShortCut.Ring2UE, "2重円(User-Event)を表示");
            shortCut.Add(EShortCut.Ring3NPT, "3重円(NPT)を表示");
            shortCut.Add(EShortCut.Plus1Second, "1秒進める");
            shortCut.Add(EShortCut.Minus1Second, "1秒戻す");
            shortCut.Add(EShortCut.Plus1Minute, "1分進める");
            shortCut.Add(EShortCut.Minus1Minute, "1分戻す");
            shortCut.Add(EShortCut.Plus1Hour, "1時間進める");
            shortCut.Add(EShortCut.Minus1Hour, "1時間戻す");
            shortCut.Add(EShortCut.Plus12Hour, "12時間進める");
            shortCut.Add(EShortCut.Minus12Hour, "12時間戻す");
            shortCut.Add(EShortCut.Plus1Day, "1日進める");
            shortCut.Add(EShortCut.Minus1Day, "1日戻す");
            shortCut.Add(EShortCut.Plus7Day, "7日進める");
            shortCut.Add(EShortCut.Minus7Day, "7日戻す");
            shortCut.Add(EShortCut.Plus30Day, "30日進める");
            shortCut.Add(EShortCut.Minus30Day, "30日戻す");
            shortCut.Add(EShortCut.Plus365Day, "365日進める");
            shortCut.Add(EShortCut.Minus365Day, "365日戻す");
            shortCut.Add(EShortCut.InvisibleAllAspect, "すべてのアスペクト線を非表示");
            shortCut.Add(EShortCut.VisibleAllAspect, "すべてのアスペクト線を表示");
            shortCut.Add(EShortCut.InVisible11, "アスペクト線(1-1)を非表示");
            shortCut.Add(EShortCut.InVisible12, "アスペクト線(1-2)を非表示");
            shortCut.Add(EShortCut.InVisible13, "アスペクト線(1-3)を非表示");
            shortCut.Add(EShortCut.InVisible22, "アスペクト線(2-2)を非表示");
            shortCut.Add(EShortCut.InVisible23, "アスペクト線(2-3)を非表示");
            shortCut.Add(EShortCut.InVisible33, "アスペクト線(3-3)を非表示");
            shortCut.Add(EShortCut.Visible11, "アスペクト線(1-1)を表示");
            shortCut.Add(EShortCut.Visible12, "アスペクト線(1-2)を表示");
            shortCut.Add(EShortCut.Visible13, "アスペクト線(1-3)を表示");
            shortCut.Add(EShortCut.Visible22, "アスペクト線(2-2)を表示");
            shortCut.Add(EShortCut.Visible23, "アスペクト線(2-3)を表示");
            shortCut.Add(EShortCut.Visible33, "アスペクト線(3-3)を表示");

            return shortCut;
        }

        public static EShortCut ShortCutStringToEnum(string s)
        {
            if (s == "未設定") return EShortCut.Noop;
            if (s == "設定0に切り替える") return EShortCut.ChagngeSetting0;
            if (s == "設定1に切り替える") return EShortCut.ChagngeSetting1;
            if (s == "設定2に切り替える") return EShortCut.ChagngeSetting2;
            if (s == "設定3に切り替える") return EShortCut.ChagngeSetting3;
            if (s == "設定4に切り替える") return EShortCut.ChagngeSetting4;
            if (s == "設定5に切り替える") return EShortCut.ChagngeSetting5;
            if (s == "設定6に切り替える") return EShortCut.ChagngeSetting6;
            if (s == "設定7に切り替える") return EShortCut.ChagngeSetting7;
            if (s == "設定8に切り替える") return EShortCut.ChagngeSetting8;
            if (s == "設定9に切り替える") return EShortCut.ChagngeSetting9;
            if (s == "1重円(User1)を表示") return EShortCut.Ring1U1;
            if (s == "1重円(User2)を表示") return EShortCut.Ring1U2;
            if (s == "1重円(Event1)を表示") return EShortCut.Ring1E1;
            if (s == "1重円(Event2)を表示") return EShortCut.Ring1E2;
            if (s == "1重円(現在時刻)を表示") return EShortCut.Ring1Current;
            if (s == "2重円(User-User)を表示") return EShortCut.Ring2UU;
            if (s == "2重円(User-Event)を表示") return EShortCut.Ring2UE;
            if (s == "3重円(NPT)を表示") return EShortCut.Ring3NPT;
            if (s == "1秒進める") return EShortCut.Plus1Second;
            if (s == "1秒戻す") return EShortCut.Minus1Second;
            if (s == "1分進める") return EShortCut.Plus1Minute;
            if (s == "1分戻す") return EShortCut.Minus1Minute;
            if (s == "1時間進める") return EShortCut.Plus1Hour;
            if (s == "1時間戻す") return EShortCut.Minus1Hour;
            if (s == "12時間進める") return EShortCut.Plus12Hour;
            if (s == "12時間戻す") return EShortCut.Minus12Hour;
            if (s == "1日進める") return EShortCut.Plus1Day;
            if (s == "1日戻す") return EShortCut.Minus1Day;
            if (s == "7日進める") return EShortCut.Plus7Day;
            if (s == "7日戻す") return EShortCut.Minus7Day;
            if (s == "30日進める") return EShortCut.Plus30Day;
            if (s == "30日戻す") return EShortCut.Minus30Day;
            if (s == "365日進める") return EShortCut.Plus365Day;
            if (s == "365日戻す") return EShortCut.Minus365Day;
            if (s == "すべてのアスペクト線を非表示") return EShortCut.InvisibleAllAspect;
            if (s == "すべてのアスペクト線を表示") return EShortCut.VisibleAllAspect;
            if (s == "アスペクト線(1-1)を非表示") return EShortCut.InVisible11;
            if (s == "アスペクト線(1-2)を非表示") return EShortCut.InVisible12;
            if (s == "アスペクト線(1-3)を非表示") return EShortCut.InVisible13;
            if (s == "アスペクト線(2-2)を非表示") return EShortCut.InVisible22;
            if (s == "アスペクト線(2-3)を非表示") return EShortCut.InVisible23;
            if (s == "アスペクト線(3-3)を非表示") return EShortCut.InVisible33;
            if (s == "アスペクト線(1-1)を表示") return EShortCut.Visible11;
            if (s == "アスペクト線(1-2)を表示") return EShortCut.Visible12;
            if (s == "アスペクト線(1-3)を表示") return EShortCut.Visible13;
            if (s == "アスペクト線(2-2)を表示") return EShortCut.Visible22;
            if (s == "アスペクト線(2-3)を表示") return EShortCut.Visible23;
            if (s == "アスペクト線(3-3)を表示") return EShortCut.Visible33;

            return EShortCut.Noop;
        }

        public static double GetNextIngressDegree(double degree)
        {
            double[] degrees = { 30.0, 60.0, 90.0, 120.0, 150.0, 180.0, 210.0, 240.0, 270.0, 300.0, 330.0 };
            if (degree > 359.5)
            {
                return 30.0;
            }
            foreach (double d in degrees)
            {
                if (degree + 0.4 < d) return d;
            }
            return 0.0;
        }

        public static double GetPrevIngressDegree(double degree)
        {
            double[] degrees = { 331.0, 301.0, 271.0, 241.0, 211.0, 181.0, 151.0, 121.0, 91.0, 61.0, 31.0 };
            if (degree < 1)
            {
                return 330.0;
            }
            foreach (double d in degrees)
            {
                if (degree > d) return d - 1.0;
            }
            return 0.0;
        }
    }
}
