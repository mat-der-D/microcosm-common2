﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microcosm.Aspect
{
    // アスペクト情報管理クラス
    // ポジションリストにぶら下がる
    public enum AspectKind
    {
        CONJUNCTION = 1,
        OPPOSITION = 2,
        INCONJUNCT = 3,
        SESQUIQUADRATE = 4,
        TRINE = 5,
        SQUARE = 6,
        SEXTILE = 7,
        SEMISEXTILE = 8, // 30 12
        SEMIQINTILE = 9, // 36 10
        NOVILE = 10, // 40 9
        SEMISQUARE = 11, // 45 8
        SEPTILE = 12, // 51.42 7
        QUINTILE = 13, // 72 5
        BIQUINTILE = 14, // 144 2.5
        QUINDECILE = 15
    };
    public enum SoftHard
    {
        SOFT = 1,
        HARD = 2
    }
    public class AspectInfo
    {
        public double sourceDegree;
        public double targetDegree; // 絶対位置
        public AspectKind aspectKind; // アスペクト種別
        public SoftHard softHard; // ソフトorハード 1:soft, 2:hard
        public int srcPlanetNo; // 自分の番号
        public int targetPlanetNo; // ターゲット番号
        public bool isDisp; // 表示するかどうか
        public double aspectDegree; // degree
    }
}
