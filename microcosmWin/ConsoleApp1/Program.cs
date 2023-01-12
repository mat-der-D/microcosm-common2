﻿using ConsoleApp1;
using SwissEphNet;
using System;


class MoonCalc
{

    public bool isApply(double sunDegree, double moonDegree, double degree)
    {
        if (sunDegree < 180)
        {
            //100度の場合、0～100と280～360がアプライ
            double mid = sunDegree + 180;
            if (moonDegree < sunDegree)
            {
                return true;
            }
            if (mid < moonDegree)
            {
                return true;
            }
            return false;
        }
        else
        {
            double mid = (sunDegree + 180) % 360;
            // 250度の場合、70度～250度がアプライ
            if (moonDegree < mid)
            {
                return false;
            }
            if (sunDegree < moonDegree)
            {
                return false;
            }
            return true;
        }
    }

    public double GetOrb(double from, double to)
    {
        double calc = Math.Abs(to - from);
        if (calc > 180) calc = 360 - calc;
        return calc;
    }

    public bool isIn(double from, double to, double degree, double orb)
    {
        double calc = GetOrb(from, to);
        if (degree - orb < calc && calc < degree + orb)
        {
            return true;
        }
        return false;
    }

    public void NewMoonMinus()
    {
        SwissEph s = new SwissEph();
        // http://www.astro.com/ftp/swisseph/ephe/archive_zip/ からDL
        s.swe_set_ephe_path("ephe");
        s.OnLoadFile += (sender, ev) => {
            if (File.Exists(ev.FileName))
            {
                ev.File = new FileStream(ev.FileName, FileMode.Open);
            } else
            {
                Console.WriteLine("no file:" + ev.FileName);
            }
        };

        // absolute position
        double[] x1 = { 0, 0, 0, 0, 0, 0 };
        double[] x2 = { 0, 0, 0, 0, 0, 0 };
        string serr = "";

        int utc_year = 0;
        int utc_month = 0;
        int utc_day = 0;
        int utc_hour = 0;
        int utc_minute = 0;
        double utc_second = 0;

        // [0]:Ephemeris Time [1]:Universal Time
        double[] dret = { 0.0, 0.0 };

        DateTime date = new DateTime(2022, 12, 18, 12, 0, 0);
        DateTime newday = date;
        s.swe_utc_time_zone(date.Year, date.Month, date.Day, 12, 0, 0, 9.0, ref utc_year, ref utc_month, ref utc_day, ref utc_hour, ref utc_minute, ref utc_second);
        s.swe_utc_to_jd(utc_year, utc_month, utc_day, utc_hour, utc_minute, utc_second, 1, dret, ref serr);

        int flag = SwissEph.SEFLG_SWIEPH | SwissEph.SEFLG_SPEED;
        s.swe_calc_ut(dret[1], 0, flag, x1, ref serr);
        s.swe_calc_ut(dret[1], 1, flag, x2, ref serr);
        double sunDegree = x1[0];
        double moonDegree = x2[0];
        int offset = 0;

        if (isIn(sunDegree, moonDegree, 0, 5))
        {
            if (isApply(sunDegree, moonDegree, 180))
            {
                offset = -1;
            }
            else
            {
                offset = -1;
            }

            newday = newday.AddDays(offset);
            s.swe_utc_time_zone(newday.Year, newday.Month, newday.Day, newday.Hour, newday.Minute, newday.Second, 9.0, ref utc_year, ref utc_month, ref utc_day, ref utc_hour, ref utc_minute, ref utc_second);
            s.swe_utc_to_jd(utc_year, utc_month, utc_day, utc_hour, utc_minute, utc_second, 1, dret, ref serr);

            s.swe_calc_ut(dret[1], 0, flag, x1, ref serr);
            s.swe_calc_ut(dret[1], 1, flag, x2, ref serr);

            sunDegree = x1[0];
            moonDegree = x2[0];
        }

        int cnt = 0;
        while (true)
        {
            double orb = GetOrb(sunDegree, moonDegree);
            if (isIn(sunDegree, moonDegree, 0, 0.01))
            {
                Console.WriteLine(sunDegree);
                Console.WriteLine(moonDegree);

                Console.WriteLine("finish. " + orb);
                break;
            }

            if (isApply(sunDegree, moonDegree, 180))
            {
                // applyするということは新月手前
                // 前の新月なので、たくさん戻す
                Console.WriteLine("-3day");
                offset = -3;
                newday = newday.AddDays(offset);
            }
            else
            {
                Console.WriteLine(orb);
                if (orb > 80)
                {
                    Console.WriteLine("-3day");
                    offset = -3;
                    newday = newday.AddDays(offset);
                }
                else if (orb > 20)
                {
                    Console.WriteLine("-1day");
                    offset = -1;
                    newday = newday.AddDays(offset);
                }
                else if (orb > 10)
                {
                    Console.WriteLine("-6hour");
                    offset = -6;
                    newday = newday.AddHours(offset);
                }
                else if (orb > 5)
                {
                    Console.WriteLine("-2hour");
                    offset = -2;
                    newday = newday.AddHours(offset);
                }
                else if (orb > 1.5)
                {
                    Console.WriteLine("-1hour");
                    offset = -1;
                    newday = newday.AddHours(offset);
                }
                else if (orb > 0.5)
                {
                    Console.WriteLine("-40min");
                    offset = -40;
                    newday = newday.AddMinutes(offset);
                }
                else if (orb > 0.2)
                {
                    Console.WriteLine("-10min");
                    offset = -10;
                    newday = newday.AddMinutes(offset);
                }
                else if (orb > 0.1)
                {
                    Console.WriteLine("-5min");
                    offset = -5;
                    newday = newday.AddMinutes(offset);
                }
                else
                {
                    Console.WriteLine("-1min");
                    offset = -1;
                    newday = newday.AddMinutes(offset);
                }
            }

            s.swe_utc_time_zone(newday.Year, newday.Month, newday.Day, newday.Hour, newday.Minute, newday.Second, 9.0, ref utc_year, ref utc_month, ref utc_day, ref utc_hour, ref utc_minute, ref utc_second);
            s.swe_utc_to_jd(utc_year, utc_month, utc_day, utc_hour, utc_minute, utc_second, 1, dret, ref serr);

            s.swe_calc_ut(dret[1], 0, flag, x1, ref serr);
            s.swe_calc_ut(dret[1], 1, flag, x2, ref serr);

            sunDegree = x1[0];
            moonDegree = x2[0];

            cnt++;
            if (cnt > 100)
            {
                Console.WriteLine("100ごえ");
                break;
            }
        }
        Console.WriteLine(newday);

    }

    public void FullMoonPlus()
    {
        SwissEph s = new SwissEph();
        // http://www.astro.com/ftp/swisseph/ephe/archive_zip/ からDL
        s.swe_set_ephe_path("ephe");
        s.OnLoadFile += (sender, ev) => {
            if (File.Exists(ev.FileName))
                ev.File = new FileStream(ev.FileName, FileMode.Open);
        };

        // absolute position
        double[] x1 = { 0, 0, 0, 0, 0, 0 };
        double[] x2 = { 0, 0, 0, 0, 0, 0 };
        string serr = "";

        int utc_year = 0;
        int utc_month = 0;
        int utc_day = 0;
        int utc_hour = 0;
        int utc_minute = 0;
        double utc_second = 0;

        // [0]:Ephemeris Time [1]:Universal Time
        double[] dret = { 0.0, 0.0 };

        DateTime date = new DateTime(2022, 12, 17, 12, 0, 0);
        DateTime newday = date;
        s.swe_utc_time_zone(2022, 12, date.Day, 12, 0, 0, 9.0, ref utc_year, ref utc_month, ref utc_day, ref utc_hour, ref utc_minute, ref utc_second);
        s.swe_utc_to_jd(utc_year, utc_month, utc_day, utc_hour, utc_minute, utc_second, 1, dret, ref serr);
        Console.WriteLine(serr);

        int flag = SwissEph.SEFLG_SWIEPH | SwissEph.SEFLG_SPEED;
        s.swe_calc_ut(dret[1], 0, flag, x1, ref serr);
        s.swe_calc_ut(dret[1], 1, flag, x2, ref serr);
        double sunDegree = x1[0];
        double moonDegree = x2[0];
        int offset = 0;

        if (isIn(sunDegree, moonDegree, 180, 10))
        {
            if (isApply(sunDegree, moonDegree, 180))
            {
                offset = 1;
            }
            else
            {
                offset = 2;
            }

            newday = newday.AddDays(offset);
            s.swe_utc_time_zone(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, 9.0, ref utc_year, ref utc_month, ref utc_day, ref utc_hour, ref utc_minute, ref utc_second);
            s.swe_utc_to_jd(utc_year, utc_month, utc_day, utc_hour, utc_minute, utc_second, 1, dret, ref serr);

            s.swe_calc_ut(dret[1], 0, flag, x1, ref serr);
            s.swe_calc_ut(dret[1], 1, flag, x2, ref serr);

            sunDegree = x1[0];
            moonDegree = x2[0];
        }

        int cnt = 0;
        while (true)
        {
            double orb = GetOrb(sunDegree, moonDegree);
            if (isIn(sunDegree, moonDegree, 180, 0.05))
            {
                Console.WriteLine("finish. " + orb);
                break;
            }

            if (isApply(sunDegree, moonDegree, 180))
            {
                // applyするということは新月に近づくということ
                // 満月からは離れる
                Console.WriteLine("+3day");
                offset = 3;
                newday = newday.AddDays(offset);
            }
            else
            {
                Console.WriteLine(orb);
                if (orb > 179)
                {
                    Console.WriteLine("+5m");
                    offset = 5;
                    newday = newday.AddMinutes(offset);
                }
                else if (orb > 177)
                {
                    Console.WriteLine("+20m");
                    offset = 20;
                    newday = newday.AddMinutes(offset);
                }
                else if (orb > 165)
                {
                    Console.WriteLine("+2h");
                    offset = 2;
                    newday = newday.AddHours(offset);
                }
                else if (orb > 130)
                {
                    Console.WriteLine("+1day");
                    offset = 1;
                    newday = newday.AddDays(offset);
                }
                else
                {
                    Console.WriteLine("+2day");
                    offset = 2;
                    newday = newday.AddDays(offset);
                }
            }

            s.swe_utc_time_zone(newday.Year, newday.Month, newday.Day, newday.Hour, newday.Minute, newday.Second, 9.0, ref utc_year, ref utc_month, ref utc_day, ref utc_hour, ref utc_minute, ref utc_second);
            s.swe_utc_to_jd(utc_year, utc_month, utc_day, utc_hour, utc_minute, utc_second, 1, dret, ref serr);

            s.swe_calc_ut(dret[1], 0, flag, x1, ref serr);
            s.swe_calc_ut(dret[1], 1, flag, x2, ref serr);

            sunDegree = x1[0];
            moonDegree = x2[0];

            cnt++;
            if (cnt > 100)
            {
                Console.WriteLine("100ごえ");
                break;
            }
        }
        Console.WriteLine(newday);
    }

    public void FullMoonMinus()
    {
        SwissEph s = new SwissEph();
        // http://www.astro.com/ftp/swisseph/ephe/archive_zip/ からDL
        s.swe_set_ephe_path("ephe");
        s.OnLoadFile += (sender, ev) => {
            if (File.Exists(ev.FileName))
            {
                ev.File = new FileStream(ev.FileName, FileMode.Open);
            }
            else
            {
                Console.WriteLine("no file:" + ev.FileName);
            }
        };

        // absolute position
        double[] x1 = { 0, 0, 0, 0, 0, 0 };
        double[] x2 = { 0, 0, 0, 0, 0, 0 };
        string serr = "";

        int utc_year = 0;
        int utc_month = 0;
        int utc_day = 0;
        int utc_hour = 0;
        int utc_minute = 0;
        double utc_second = 0;

        // [0]:Ephemeris Time [1]:Universal Time
        double[] dret = { 0.0, 0.0 };

        DateTime date = new DateTime(2021, 10, 20, 23, 57, 45);
        DateTime newday = date;
        s.swe_utc_time_zone(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, 9.0, ref utc_year, ref utc_month, ref utc_day, ref utc_hour, ref utc_minute, ref utc_second);
        s.swe_utc_to_jd(utc_year, utc_month, utc_day, utc_hour, utc_minute, utc_second, 1, dret, ref serr);

        int flag = SwissEph.SEFLG_SWIEPH | SwissEph.SEFLG_SPEED;
        s.swe_calc_ut(dret[1], 0, flag, x1, ref serr);
        s.swe_calc_ut(dret[1], 1, flag, x2, ref serr);
        double sunDegree = x1[0];
        double moonDegree = x2[0];
        int offset = 0;

        if (isIn(sunDegree, moonDegree, 180, 5))
        {
            if (isApply(sunDegree, moonDegree, 180))
            {
                offset = -1;
            }
            else
            {
                offset = -1;
            }

            newday = newday.AddDays(offset);
            s.swe_utc_time_zone(newday.Year, newday.Month, newday.Day, newday.Hour, newday.Minute, newday.Second, 9.0, ref utc_year, ref utc_month, ref utc_day, ref utc_hour, ref utc_minute, ref utc_second);
            s.swe_utc_to_jd(utc_year, utc_month, utc_day, utc_hour, utc_minute, utc_second, 1, dret, ref serr);

            s.swe_calc_ut(dret[1], 0, flag, x1, ref serr);
            s.swe_calc_ut(dret[1], 1, flag, x2, ref serr);

            sunDegree = x1[0];
            moonDegree = x2[0];
        }

        int cnt = 0;
        while (true)
        {
            double orb = GetOrb(sunDegree, moonDegree);
            Console.WriteLine(sunDegree - moonDegree);

            if (isIn(sunDegree, moonDegree, 180, 0.01))
            {
                Console.WriteLine(sunDegree);
                Console.WriteLine(moonDegree);

                Console.WriteLine("finish. " + orb);
                break;
            }

            if (isApply(sunDegree, moonDegree, 180))
            {
                // applyということは満月過ぎ
                if (orb > 179.9)
                {
                    Console.WriteLine("-1min");
                    offset = -1;
                    newday = newday.AddMinutes(offset);
                }
                else if (orb > 179)
                {
                    Console.WriteLine("-10min");
                    offset = -10;
                    newday = newday.AddMinutes(offset);
                }
                else if (orb > 178)
                {
                    Console.WriteLine("-20min");
                    offset = -20;
                    newday = newday.AddMinutes(offset);
                }
                else if (orb > 175)
                {
                    Console.WriteLine("-1hour");
                    offset = -1;
                    newday = newday.AddHours(offset);
                }
                else if (orb > 170)
                {
                    Console.WriteLine("-3hour");
                    offset = -1;
                    newday = newday.AddHours(offset);
                }
                else if (orb > 130)
                {
                    Console.WriteLine("-1day");
                    offset = -1;
                    newday = newday.AddDays(offset);
                }
                else
                {
                    Console.WriteLine("-3day:" + orb);
                    offset = -3;
                    newday = newday.AddDays(offset);
                }



            }
            else
            {
                // セパレートしている、つまり戻すと新月に近づく

                Console.WriteLine("-3dayB" + newday.ToString());
                offset = -3;
                newday = newday.AddDays(offset);


            }

            s.swe_utc_time_zone(newday.Year, newday.Month, newday.Day, newday.Hour, newday.Minute, newday.Second, 9.0, ref utc_year, ref utc_month, ref utc_day, ref utc_hour, ref utc_minute, ref utc_second);
            s.swe_utc_to_jd(utc_year, utc_month, utc_day, utc_hour, utc_minute, utc_second, 1, dret, ref serr);

            s.swe_calc_ut(dret[1], 0, flag, x1, ref serr);
            s.swe_calc_ut(dret[1], 1, flag, x2, ref serr);

            sunDegree = x1[0];
            moonDegree = x2[0];
            Console.WriteLine(String.Format("{0} {1}", sunDegree, moonDegree));

            cnt++;
            if (cnt > 100)
            {
                Console.WriteLine("100ごえ");
                break;
            }
        }
        Console.WriteLine(newday);

    }

    public static void Main()
    {
        MoonCalc moon = new MoonCalc();

        bool x = false;

        //x = moon.isApply(100, 120, 180);
        //Console.WriteLine(x.ToString());
        //x = moon.isApply(100, 90, 180);
        //Console.WriteLine(x.ToString());

        /*
        x = moon.isIn(340, 341, 0, 3);
        Console.WriteLine(x.ToString());
        x = moon.isIn(340, 344, 0, 3);
        Console.WriteLine(x.ToString());
        x = moon.isIn(359, 0, 0, 3);
        Console.WriteLine(x.ToString());
        x = moon.isIn(340, 339, 0, 3);
        Console.WriteLine(x.ToString());
        x = moon.isIn(0, 359, 0, 3);
        Console.WriteLine(x.ToString());
        */

        //        moon.NewMoonMinus();
        //moon.FullMoonMinus();

        //        moon.FullMoonPlus();

        EclipseCalc eclipse = new EclipseCalc();

        eclipse.GetEclipse(new DateTime(2022, 12, 19, 12, 0, 0), 9.0, 0, 267.0, false);

    }
}



