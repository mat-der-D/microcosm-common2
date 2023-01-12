using microcosm.common;
using microcosm.config;
using microcosm.calc;
using microcosm.Planet;
using microcosm.Aspect;
using NUnit.Framework;

namespace microcosmTest
{
    /// <summary>
    /// ���I�[�u�������A���͕ʃN���X��
    /// </summary>
    public class Orb1st
    {
        [SetUp]
        public void Setup()
        {

        }

        /// <summary>
        /// Orb1st����Ȃ���OrbSunMoon���g���Ă��邩
        /// </summary>
        [Test]
        public void testOrbSun()
        {
            SettingData setting = new SettingData(0);
            setting.orb1st[0] = 0;
            setting.orb1st[1] = 0;
            // sun��8,6�ɂȂ��Ă���

            Dictionary<int, PlanetData> list = new Dictionary<int, PlanetData>();
            list.Add(CommonData.ZODIAC_SUN, new PlanetData()
            {
                no = CommonData.ZODIAC_SUN,
                absolute_position = 100.0,
                isAspectDisp = true,
                isDisp = true,
                speed = 1.0,
                aspects = new List<AspectInfo>(),
                secondAspects = new List<AspectInfo>(),
                thirdAspects = new List<AspectInfo>(),
                sensitive = false
            });
            //5�x�n�[�h
            list.Add(CommonData.ZODIAC_MOON, new PlanetData()
            {
                no = CommonData.ZODIAC_MOON,
                absolute_position = 285.0,
                isAspectDisp = true,
                isDisp = true,
                speed = 1.0,
                aspects = new List<AspectInfo>(),
                secondAspects = new List<AspectInfo>(),
                thirdAspects = new List<AspectInfo>(),
                sensitive = false
            });
            //�ΏۊO
            list.Add(CommonData.ZODIAC_MERCURY, new PlanetData()
            {
                no = CommonData.ZODIAC_MERCURY,
                absolute_position = 289.0,
                isAspectDisp = true,
                isDisp = true,
                speed = 1.0,
                aspects = new List<AspectInfo>(),
                secondAspects = new List<AspectInfo>(),
                thirdAspects = new List<AspectInfo>(),
                sensitive = false
            });
            //7�x�\�t�g
            list.Add(CommonData.ZODIAC_VENUS, new PlanetData()
            {
                no = CommonData.ZODIAC_VENUS,
                absolute_position = 287.0,
                isAspectDisp = true,
                isDisp = true,
                speed = 1.0,
                aspects = new List<AspectInfo>(),
                secondAspects = new List<AspectInfo>(),
                thirdAspects = new List<AspectInfo>(),
                sensitive = false
            });
            AspectCalc aspect = new AspectCalc();
            Dictionary<int, PlanetData> result = aspect.AspectCalcSame(setting, list);
            Assert.That(result[CommonData.ZODIAC_SUN].aspects.Count, Is.EqualTo(2));
            Assert.That(result[CommonData.ZODIAC_SUN].aspects[0].aspectKind, Is.EqualTo(AspectKind.OPPOSITION)); ;
            Assert.That(result[CommonData.ZODIAC_SUN].aspects[0].softHard, Is.EqualTo(SoftHard.HARD)); ;
            Assert.That(result[CommonData.ZODIAC_SUN].aspects[1].aspectKind, Is.EqualTo(AspectKind.OPPOSITION)); ;
            Assert.That(result[CommonData.ZODIAC_SUN].aspects[1].softHard, Is.EqualTo(SoftHard.SOFT)); ;
        }

        /// <summary>
        /// Orb1st����Ȃ���OrbSunMoon���g���Ă��邩Moon��
        /// </summary>
        [Test]
        public void testOrbMoon()
        {
            SettingData setting = new SettingData(0);
            setting.orb1st[0] = 0;
            setting.orb1st[1] = 0;
            // sun��8,6�ɂȂ��Ă���

            Dictionary<int, PlanetData> list = new Dictionary<int, PlanetData>();
            list.Add(CommonData.ZODIAC_MOON, new PlanetData()
            {
                no = CommonData.ZODIAC_MOON,
                absolute_position = 100.0,
                isAspectDisp = true,
                isDisp = true,
                speed = 1.0,
                aspects = new List<AspectInfo>(),
                secondAspects = new List<AspectInfo>(),
                thirdAspects = new List<AspectInfo>(),
                sensitive = false
            });
            //5�x�n�[�h
            list.Add(CommonData.ZODIAC_MERCURY, new PlanetData()
            {
                no = CommonData.ZODIAC_MERCURY,
                absolute_position = 285.0,
                isAspectDisp = true,
                isDisp = true,
                speed = 1.0,
                aspects = new List<AspectInfo>(),
                secondAspects = new List<AspectInfo>(),
                thirdAspects = new List<AspectInfo>(),
                sensitive = false
            });
            //�ΏۊO
            list.Add(CommonData.ZODIAC_VENUS, new PlanetData()
            {
                no = CommonData.ZODIAC_VENUS,
                absolute_position = 289.0,
                isAspectDisp = true,
                isDisp = true,
                speed = 1.0,
                aspects = new List<AspectInfo>(),
                secondAspects = new List<AspectInfo>(),
                thirdAspects = new List<AspectInfo>(),
                sensitive = false
            });
            //7�x�\�t�g
            list.Add(CommonData.ZODIAC_MARS, new PlanetData()
            {
                no = CommonData.ZODIAC_MARS,
                absolute_position = 287.0,
                isAspectDisp = true,
                isDisp = true,
                speed = 1.0,
                aspects = new List<AspectInfo>(),
                secondAspects = new List<AspectInfo>(),
                thirdAspects = new List<AspectInfo>(),
                sensitive = false
            });
            AspectCalc aspect = new AspectCalc();
            Dictionary<int, PlanetData> result = aspect.AspectCalcSame(setting, list);
            Assert.That(result[CommonData.ZODIAC_MOON].aspects.Count, Is.EqualTo(2));
            Assert.That(result[CommonData.ZODIAC_MOON].aspects[0].aspectKind, Is.EqualTo(AspectKind.OPPOSITION)); ;
            Assert.That(result[CommonData.ZODIAC_MOON].aspects[0].softHard, Is.EqualTo(SoftHard.HARD)); ;
            Assert.That(result[CommonData.ZODIAC_MOON].aspects[1].aspectKind, Is.EqualTo(AspectKind.OPPOSITION)); ;
            Assert.That(result[CommonData.ZODIAC_MOON].aspects[1].softHard, Is.EqualTo(SoftHard.SOFT)); ;
        }

        /// <summary>
        /// Orb1st��
        /// </summary>
        [Test]
        public void testOrb1st()
        {
            SettingData setting = new SettingData(0);
            // 6,4�ɂȂ��Ă���

            Dictionary<int, PlanetData> list = new Dictionary<int, PlanetData>();
            list.Add(CommonData.ZODIAC_MERCURY, new PlanetData()
            {
                no = CommonData.ZODIAC_MERCURY,
                absolute_position = 100.0,
                isAspectDisp = true,
                isDisp = true,
                speed = 1.0,
                aspects = new List<AspectInfo>(),
                secondAspects = new List<AspectInfo>(),
                thirdAspects = new List<AspectInfo>(),
                sensitive = false
            });
            //3�x�n�[�h
            list.Add(CommonData.ZODIAC_VENUS, new PlanetData()
            {
                no = CommonData.ZODIAC_VENUS,
                absolute_position = 283.0,
                isAspectDisp = true,
                isDisp = true,
                speed = 1.0,
                aspects = new List<AspectInfo>(),
                secondAspects = new List<AspectInfo>(),
                thirdAspects = new List<AspectInfo>(),
                sensitive = false
            });
            //�ΏۊO
            list.Add(CommonData.ZODIAC_MARS, new PlanetData()
            {
                no = CommonData.ZODIAC_MARS,
                absolute_position = 287.0,
                isAspectDisp = true,
                isDisp = true,
                speed = 1.0,
                aspects = new List<AspectInfo>(),
                secondAspects = new List<AspectInfo>(),
                thirdAspects = new List<AspectInfo>(),
                sensitive = false
            });
            //5�x�\�t�g
            list.Add(CommonData.ZODIAC_JUPITER, new PlanetData()
            {
                no = CommonData.ZODIAC_JUPITER,
                absolute_position = 285.0,
                isAspectDisp = true,
                isDisp = true,
                speed = 1.0,
                aspects = new List<AspectInfo>(),
                secondAspects = new List<AspectInfo>(),
                thirdAspects = new List<AspectInfo>(),
                sensitive = false
            });
            AspectCalc aspect = new AspectCalc();
            Dictionary<int, PlanetData> result = aspect.AspectCalcSame(setting, list);
            Assert.That(result[CommonData.ZODIAC_MERCURY].aspects.Count, Is.EqualTo(2));
            Assert.That(result[CommonData.ZODIAC_MERCURY].aspects[0].aspectKind, Is.EqualTo(AspectKind.OPPOSITION)); ;
            Assert.That(result[CommonData.ZODIAC_MERCURY].aspects[0].softHard, Is.EqualTo(SoftHard.HARD)); ;
            Assert.That(result[CommonData.ZODIAC_MERCURY].aspects[1].aspectKind, Is.EqualTo(AspectKind.OPPOSITION)); ;
            Assert.That(result[CommonData.ZODIAC_MERCURY].aspects[1].softHard, Is.EqualTo(SoftHard.SOFT)); ;
        }
    }
}