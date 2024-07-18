using System.ComponentModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleProject1
{
    internal class Program
    {
        #region enum 모음
        enum Lifepath { Nomad = 1, StreetKid, Corpo }
        enum Perk { Body = 1, Intelligence, Reflexes, Tech, Cool }
        enum Scene { Select, Confirm, Intro, Spaceship, Entrance, Security, Battle1, Battle2, Boss, Ending }
        enum Memento { IdCard, Tools, Diary, Empty }

        struct Enemy
        {
            public string name;
            public string description;
            public int damage;
            public int enemyMaxHp;
            public int enemyCurHp;
        }
        #endregion

        #region enum 상수 한글화
        static string GetLifepathName(Lifepath lifepath)
        {
            switch (lifepath)
            {
                case Lifepath.Nomad:
                    return "노마드";
                case Lifepath.StreetKid:
                    return "부랑자";
                case Lifepath.Corpo:
                    return "기업인";
                default:
                    return "";
            }
        }

        static string GetMementoName(Memento memento)
        {
            switch (memento)
            {
                case Memento.IdCard:
                    return "아라사카 ID카드";
                case Memento.Tools:
                    return "노마드의 맥가이버칼";
                case Memento.Diary:
                    return "부랑자의 일기장";
                default:
                    return "";
            }
        }

        static string GetPerkName(Perk perk)
        {
            switch (perk)
            {
                case Perk.Body:
                    return "신체";
                case Perk.Intelligence:
                    return "지능";
                case Perk.Reflexes:
                    return "반사신경";
                case Perk.Tech:
                    return "기술";
                case Perk.Cool:
                    return "냉정";
                default:
                    return "";
            }
        }
        #endregion

        #region GameData
        struct GameData
        {
            public bool running;

            public Scene scene;

            public string name;
            public Lifepath lifepath;
            public Perk perk;
            public int maxHp;
            public int curHp;
            public int STR;
            public int INT;
            public int RFX;
            public int TEC;
            public int COL;
            public Memento memento;
        }

        static GameData data;
        #endregion

        #region 랜덤계산 bool
        static bool RandomSuccess(int i)
        {
            Random rand = new Random();
            int dice = rand.Next(10);
            return dice < (i - 1);
        }
        #endregion

        #region 랜덤계산 damage
        static int RandomDamage(int i)
        {
            Random rand = new Random();
            int dice = rand.Next(i, 21);
            return dice;
        }
        #endregion

        #region Main
        static void Main(string[] args)
        {
            Start();

            while (data.running)
            {
                Run();
            }

            End();
        }
        #endregion

        #region 시작화면, 종료화면
        static void Start()
        {
            data = new GameData();

            data.running = true;
            Console.SetCursorPosition(0, 0);
            Console.Clear();
            Console.WriteLine();
            Wait(10);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" _____ __   ________  _____ ______ ______  _   _  _   _  _   __");
            Console.WriteLine("/  __ \\\\ \\ / /| ___ \\|  ___|| ___ \\| ___ \\| | | || \\ | || | / /");
            Console.WriteLine("| /  \\/ \\ V / | |_/ /| |__  | |_/ /| |_/ /| | | ||  \\| || |/ / ");
            Console.WriteLine("| |      \\ /  | ___ \\|  __| |    / |  __/ | | | || . ` ||    \\ ");
            Console.WriteLine("| \\__/\\  | |  | |_/ /| |___ | |\\ \\ | |    | |_| || |\\  || |\\  \\");
            Console.WriteLine(" \\____/  \\_/  \\____/ \\____/ \\_| \\_|\\_|     \\___/ \\_| \\_/\\_| \\_/");
            Console.WriteLine();
            Console.WriteLine();
            Wait(10);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine();
            Console.WriteLine("                 _ _   __|_ _ |   _  _ | _  _ _ ");
            Console.WriteLine("                (_| \\/_\\ | (_||  |_)(_||(_|(_(/_");
            Console.WriteLine("                    /            |              ");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();
            Wait(10);
            GoNext();
        }

        static void End()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("================================");
            Console.WriteLine("=                              =");
            Console.WriteLine("=                              =");
            Console.WriteLine("=     게임이 종료되었습니다.   =");
            Console.WriteLine("=                              =");
            Console.WriteLine("=                              =");
            Console.WriteLine("================================");
            Console.WriteLine();
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("콘솔을 종료하시려면 아무 키나 눌러주세요.");
            Console.ReadKey(true);

        }
        #endregion

        #region Run
        static void Run()
        {
            Console.Clear();

            switch (data.scene)
            {
                case Scene.Select:
                    SelectScene();
                    break;
                case Scene.Confirm:
                    ConfirmScene();
                    break;
                case Scene.Intro:
                    IntroScene();
                    break;
                case Scene.Spaceship:
                    SpaceshipScene();
                    break;
                case Scene.Entrance:
                    EntranceScene();
                    break;
                case Scene.Security:
                    SecurityScene();
                    break;
                case Scene.Battle1:
                    Battle1Scene();
                    break;
                case Scene.Battle2:
                    Battle2Scene();
                    break;
                case Scene.Boss:
                    BossScene();
                    break;
                case Scene.Ending:
                    EndingScene();
                    break;
            }
        }
        #endregion

        #region 프로필 출력
        static void PrintProfile()
        {
            Console.WriteLine("================================");
            Console.WriteLine($"이름 : {data.name}");
            Console.WriteLine($"출신 : {GetLifepathName(data.lifepath)}");
            Console.WriteLine($"체력 : {data.curHp} / {data.maxHp}");
            Console.WriteLine($"특전 : {GetPerkName(data.perk)}");
            Console.WriteLine($"소지품 : {GetMementoName(data.memento)}");
            Console.WriteLine("================================");
            Console.WriteLine();
        }
        #endregion

        #region Wait
        static void Wait(float seconds)
        {
            Thread.Sleep((int)(seconds * 100));
        }
        #endregion

        #region GoNext
        static void GoNext()
        {
            Console.WriteLine();
            Console.WriteLine("다음으로 이동하시려면 아무 키나 입력해주세요.");
            Console.ReadKey(true);
        }
        #endregion

        #region 캐릭터 설정
        static void SelectScene()
        {
            Console.Write("캐릭터의 이름을 입력하세요 - ");
            data.name = Console.ReadLine();
            if (data.name == "")
            {
                Console.WriteLine("잘못된 입력입니다.");
                Wait(5);
                return;
            }

            Console.WriteLine();
            Wait(5);
            Console.Clear();
            Console.WriteLine("캐릭터의 출신을 선택하세요.");
            Console.WriteLine();
            Wait(5);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("출신에 따라서 게임 내에서 특수한 역할을 하는 소지품이 있습니다.");
            Console.ResetColor();
            Console.WriteLine();
            Wait(5);
            Console.WriteLine("=======================================================================");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1. 노마드");
            Console.WriteLine();
            Console.ResetColor();
            Console.WriteLine("노마드는 황무지에서 떠돌던 무리속 인물로, 온갖 잡다한 기술을 가지고 있습니다.");
            Console.WriteLine("소지품 : 노마드의 맥가이버칼");
            Console.ForegroundColor = ConsoleColor.Blue;
            Wait(3);
            Console.WriteLine();
            Console.WriteLine("2. 부랑자");
            Console.WriteLine();
            Console.ResetColor();
            Console.WriteLine("부랑자는 할렘가의 길바닥에서 자라와 갱단의 생리에 빠삭합니다.");
            Console.WriteLine("소지품 : 부랑자의 일기장");
            Console.ForegroundColor = ConsoleColor.Red;
            Wait(3);
            Console.WriteLine();
            Console.WriteLine("3. 기업인");
            Console.WriteLine();
            Console.ResetColor();
            Console.WriteLine("기업인은 대기업 직원 출신으로 기업의 일 처리 방식에 익숙합니다.");
            Console.WriteLine("소지품 : 아라사카 ID카드");
            Console.WriteLine("=======================================================================");
            Console.WriteLine();
            Wait(3);
            Console.Write("출신을 골라주세요 - ");
            if (int.TryParse(Console.ReadLine(), out int select) == false)
            {
                Console.WriteLine("잘못된 입력입니다.");
                Wait(5);
                return;
            }
            else if (Enum.IsDefined(typeof(Lifepath), select) == false)
            {
                Console.WriteLine("잘못된 입력입니다.");
                Wait(5);
                return;
            }

            switch ((Lifepath)select)
            {
                case Lifepath.Nomad:
                    data.lifepath = Lifepath.Nomad;
                    data.memento = Memento.Tools;
                    break;
                case Lifepath.StreetKid:
                    data.lifepath = Lifepath.StreetKid;
                    data.memento = Memento.Diary;
                    break;
                case Lifepath.Corpo:
                    data.lifepath = Lifepath.Corpo;
                    data.memento = Memento.IdCard;
                    break;
            }

            Console.WriteLine();
            Wait(5);
            Console.Clear();
            Console.WriteLine("캐릭터의 특전을 선택하세요.");
            Console.WriteLine();
            Wait(5);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("특전에 따라서 캐릭터의 스탯이 결정됩니다.");
            Console.WriteLine();
            Console.WriteLine("특전에 따른 스탯은 공개되지 않으며 성공 확률에 영향을 끼칩니다.");
            Console.WriteLine();
            Console.ResetColor();
            Console.WriteLine();
            Wait(5);
            Console.WriteLine("=======================================================================");
            Console.WriteLine("1. 신체");
            Wait(2);
            Console.WriteLine("2. 지능");
            Wait(2);
            Console.WriteLine("3. 반사신경");
            Wait(2);
            Console.WriteLine("4. 기술");
            Wait(2);
            Console.WriteLine("5. 냉정");
            Console.WriteLine("=======================================================================");
            Wait(2);
            Console.WriteLine();
            Console.Write("특전을 골라주세요 - ");
            if (int.TryParse(Console.ReadLine(), out int select2) == false)
            {
                Console.WriteLine("잘못된 입력입니다.");
                Wait(5);
                return;
            }
            else if (Enum.IsDefined(typeof(Perk), select2) == false)
            {
                Console.WriteLine("잘못된 입력입니다.");
                Wait(5);
                return;
            }

            switch ((Perk)select2)
            {
                case Perk.Body:
                    data.perk = Perk.Body;
                    data.maxHp = 120;
                    data.curHp = data.maxHp;
                    data.STR = 8;
                    data.INT = 2;
                    data.RFX = 6;
                    data.TEC = 4;
                    data.COL = 3;
                    break;
                case Perk.Intelligence:
                    data.perk = Perk.Intelligence;
                    data.maxHp = 100;
                    data.curHp = data.maxHp;
                    data.STR = 3;
                    data.INT = 8;
                    data.RFX = 5;
                    data.TEC = 6;
                    data.COL = 3;
                    break;
                case Perk.Reflexes:
                    data.perk = Perk.Reflexes;
                    data.maxHp = 110;
                    data.curHp = data.maxHp;
                    data.STR = 4;
                    data.INT = 3;
                    data.RFX = 8;
                    data.TEC = 4;
                    data.COL = 5;
                    break;
                case Perk.Tech:
                    data.perk = Perk.Tech;
                    data.maxHp = 110;
                    data.curHp = data.maxHp;
                    data.STR = 4;
                    data.INT = 4;
                    data.RFX = 4;
                    data.TEC = 8;
                    data.COL = 4;
                    break;
                case Perk.Cool:
                    data.perk = Perk.Cool;
                    data.maxHp = 100;
                    data.curHp = data.maxHp;
                    data.STR = 3;
                    data.INT = 5;
                    data.RFX = 3;
                    data.TEC = 6;
                    data.COL = 8;
                    break;
            }
            data.scene = Scene.Confirm;

        }
        #endregion

        #region 캐릭터 설정 확인
        static void ConfirmScene()
        {
            Console.WriteLine("================================");
            Console.WriteLine($"이름 : {data.name}");
            Console.WriteLine($"출신 : {GetLifepathName(data.lifepath)}");
            Console.WriteLine($"소지품 : {GetMementoName(data.memento)}");
            Console.WriteLine($"특전 : {GetPerkName(data.perk)}");
            Console.WriteLine("================================");
            Console.WriteLine();
            Wait(5);
            Console.WriteLine("이대로 플레이 하시겠습니까?");
            Console.Write("(Y / N)를 입력해주세요 - ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "Y":
                case "y":
                    Console.Clear();
                    Console.WriteLine("인트로로 이동합니다.");
                    Wait(20);
                    data.scene = Scene.Intro;
                    break;
                case "N":
                case "n":
                    Console.Clear();
                    Console.WriteLine("다시 캐릭터 설정창으로 이동합니다.");
                    Wait(10);
                    data.scene = Scene.Select;
                    break;
                default:
                    data.scene = Scene.Confirm;
                    break;
            }
        }
        #endregion

        #region 인트로
        static void IntroScene()
        {
            Console.WriteLine("인트로");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("본 게임은 '사이버펑크 2077'의 태양엔딩 이후의 시점입니다.");
            Wait(3);
            Console.WriteLine("게임의 모든 선택은 스탯에 따른 확률 계산으로 성공/실패가 나뉘어집니다.");
            Console.ResetColor();
            Console.WriteLine("");
            Wait(5);
            Console.WriteLine("=====================================================");
            Console.WriteLine("'사이버펑크 2077'에서 애프터라이프의 제왕이자, 용병계");
            Wait(5);
            Console.WriteLine($"의 거물이 된 {data.name}(V)는 '아라사카'가 보안을 담당하고 있는 ");
            Wait(5);
            Console.WriteLine("우주 정거장 '크리스탈 팰리스'에 침입해 의문의 고객");
            Wait(5);
            Console.WriteLine("명부를 탈취하는 임무를 받습니다.");
            Wait(5);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("당신은 지금 우주선 Black Comet으로 항해중입니다.");
            Console.ResetColor();
            Console.WriteLine("=====================================================");
            Wait(5);
            GoNext();
            data.scene = Scene.Spaceship;
        }
        #endregion

        #region 우주선
        static void SpaceshipScene()
        {
            PrintProfile();
            Wait(15);
            Console.WriteLine("당신은 며칠 째 우주정거장을 향해 홀로 항해하고 있습니다.");
            Wait(15);
            Console.WriteLine("지루한 항해는 계속되었고 이제 우주정거장이 코앞입니다.");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Wait(15);
            Console.WriteLine("비상 ! 비상 ! 비상 !");
            Console.ResetColor();
            Wait(15);
            Console.WriteLine();
            Console.WriteLine("우주선의 항법 장치에 문제가 생겼습니다.");
            Wait(15);
            Console.WriteLine("어떻게 대처하시겠습니까?");
            Console.WriteLine();
            Wait(5);
            Console.WriteLine("=======================================================================");
            Console.WriteLine($"1. (지능 + 기술) 수리를 시도한다.");
            Wait(3);
            Console.WriteLine($"2. (반사신경 + 냉정) 수리를 할 자신은 없다. 침착하게 상황을 판단한 후, 대피한다.");
            Wait(3);
            Console.WriteLine($"3. (힘) 비상 장치를 작동 시킨다.");
            Console.WriteLine("=======================================================================");
            Console.WriteLine();
            Wait(3);

            Console.Write("선택지를 입력해주세요 - ");
            int select;

            bool success = int.TryParse(Console.ReadLine(), out select);


            if (success == false)
            {
                Console.WriteLine("잘못된 입력입니다.");
                Wait(5);
                return;
            }
            else if (select <= 0 || select >= 4)
            {
                Console.WriteLine("잘못된 입력입니다.");
                Wait(5);
                return;
            }

            switch (select)
            {
                case 1:
                    if (RandomSuccess((data.INT + data.TEC) / 2))
                    {
                        Wait(10);
                        Console.WriteLine();
                        Wait(15);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("당신은 우주선의 수리에 성공하였고 안전하게 착륙했습니다.");
                        Wait(15);
                        Console.WriteLine("기술이 1 상승했습니다.");
                        Console.ResetColor();
                        data.TEC++;
                        Wait(10);
                        GoNext();
                    }
                    else
                    {
                        Wait(10);
                        Console.WriteLine();
                        Wait(15);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("수리에 실패했습니다..");
                        Wait(15);
                        Console.WriteLine("우주선은 추락했고 당신은 부상을 당했습니다..");
                        Wait(15);
                        Console.WriteLine("체력이 10 감소했습니다.");
                        Console.ResetColor();
                        Wait(10);
                        data.curHp -= 10;
                        GoNext();
                    }
                    break;
                case 2:
                    if (RandomSuccess((data.RFX + data.COL) / 2))
                    {
                        Wait(10);
                        Console.WriteLine();
                        Wait(15);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("당신은 침착하게 행동한 결과, 피해를 최소화하고 착륙할 수 있었습니다.");
                        Wait(15);
                        Console.WriteLine("체력이 1 감소했지만 반사 신경이 1 상승했습니다.");
                        Console.ResetColor();
                        Wait(10);
                        data.curHp -= 1;
                        data.RFX++;
                        GoNext();
                    }
                    else
                    {
                        Wait(10);
                        Console.WriteLine();
                        Wait(15);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("당신은 침착하게 대응하려고 했지만 대피할 곳을 찾지 못했습니다..");
                        Wait(15);
                        Console.WriteLine("우주선은 추락했고 당신은 큰 피해를 입었습니다..");
                        Wait(15);
                        Console.WriteLine("체력이 10 감소했습니다.");
                        Console.ResetColor();
                        data.curHp -= 10;
                        Wait(10);
                        GoNext();
                    }
                    break;
                case 3:
                    if (RandomSuccess(data.STR))
                    {
                        Wait(10);
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Wait(15);
                        Console.WriteLine("당신은 힘으로 비상장치를 가동하는데 성공했고, 안전하게 착륙했습니다.");
                        Wait(10);
                        Console.ResetColor();
                        GoNext();
                    }
                    else
                    {
                        Wait(10);
                        Console.WriteLine();
                        Wait(15);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("당신의 힘으로 비상장치를 제 시간내에 가동하는데 실패했고, 추락후 큰 부상을 입었습니다..");
                        Wait(15);
                        Console.WriteLine("체력이 10 감소했습니다.");
                        Console.ResetColor();
                        data.curHp -= 10;
                        Wait(10);
                        GoNext();
                    }
                    break;
            }
            data.scene = Scene.Entrance;
        }
        #endregion

        #region 우주정거장 입구
        static void EntranceScene()
        {
            PrintProfile();
            Wait(15);
            Console.WriteLine("그렇게 당신은 우여곡절 끝에 우주정거장의 입구에 도착했습니다.");
            Console.WriteLine();
            Wait(15);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("우주 정거장의 입구에는 아라카사의 보안부 직원이 경계중입니다.");
            Console.WriteLine();
            Console.ResetColor();
            Wait(15);

            if (data.lifepath == Lifepath.Corpo)
            {
                Console.WriteLine("기업 출신인 당신은 그의 낮은 직급을 알아봅니다.");
                Wait(15);
                Console.WriteLine();
                Console.WriteLine("당신은 아라사카 ID카드를 소모해 높은 확률로 문을 지나갈 수 있습니다.");
                Console.WriteLine();
                Wait(15);
                Console.Write("시도하시려면 y, 전투를 실행하시려면 n을 입력해주세요 - ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "Y":
                    case "y":
                        if (RandomSuccess(9))
                        {
                            Wait(10);
                            Console.WriteLine();
                            Console.WriteLine("당신은 과거의 ID카드를 보여주고 보안직원을 권위로 압박했습니다.");
                            Wait(15);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("당신은 우주 정거장의 입구를 무사히 통과했습니다.");
                            Wait(15);
                            Console.ResetColor();
                            Console.WriteLine("아라사카 ID카드를 소모했습니다.");
                            Console.WriteLine();
                            data.memento = Memento.Empty;
                            Wait(10);
                            GoNext();
                            data.scene = Scene.Security;
                        }
                        else
                        {
                            Wait(10);
                            Console.WriteLine();
                            Console.WriteLine("당신은 ID카드를 보여주지만 수상하게 여긴 직원이 데이터를 검사했습니다..");
                            Wait(15);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("과거의 카드라는 것을 알아챈 직원은 곧바로 전투태세에 들어갑니다.");
                            Wait(15);
                            Console.ResetColor();
                            Console.WriteLine("아라사카 ID카드만 소모했습니다.");
                            Console.WriteLine();
                            data.memento = Memento.Empty;
                            Wait(10);
                            GoNext();
                            data.scene = Scene.Battle1;
                        }
                        break;
                    case "N":
                    case "n":
                        {
                            Wait(10);
                            Console.WriteLine();
                            Console.WriteLine("당신은 곱게 지나갈 생각이 없습니다.");
                            Wait(15);
                            Console.WriteLine("당신은 바로 공격을 시도합니다.");
                            Wait(10);
                            Console.WriteLine();
                            GoNext();
                            data.scene = Scene.Battle1;
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("잘못 입력했습니다.");
                            Wait(10);
                        }
                        break;
                }
            }

            else
            {
                Console.WriteLine("당신의 머릿속에는 그를 지나갈 몇가지 방법이 떠오릅니다.");
                Wait(5);
                Console.WriteLine();
                Console.WriteLine("=======================================================================");
                Console.WriteLine("1. (냉정) 보안요원을 기만한다. 정거장 내부의 중요한 인물을 만나러 간다고 거짓말한다.");
                Wait(3);
                Console.WriteLine("2. (기술) 보안 패널을 해킹해 경보를 무력화 시킨 후 몰래 지나간다.");
                Wait(3);
                Console.WriteLine("3. 그딴건 없다. 싸우자.");
                Console.WriteLine("=======================================================================");
                Wait(3);
                Console.WriteLine();
                Console.Write("선택지를 입력해주세요 - ");
                int select;

                bool success = int.TryParse(Console.ReadLine(), out select);

                if (success == false)
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Wait(5);
                    return;
                }
                else if (select <= 0 || select >= 4)
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Wait(5);
                    return;
                }

                switch (select)
                {
                    case 1:
                        if (RandomSuccess((data.COL)))
                        {
                            Wait(10);
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("보안요원은 당신의 말에 설득당했습니다.");
                            Wait(15);
                            Console.WriteLine("보안요원은 문을 활짝 열어줬고, 당신은 아무 문제없이 지나갔습니다.");
                            Wait(15);
                            Console.WriteLine("냉정이 1 상승했습니다.");
                            Console.ResetColor();
                            Console.WriteLine();
                            data.COL++;
                            Wait(10);
                            GoNext();
                            data.scene = Scene.Security;
                        }
                        else
                        {
                            Wait(10);
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("보안요원은 당신의 말을 들은채도 하지 않은 채 신분증을 요구합니다.");
                            Wait(15);
                            Console.WriteLine("당신은 어쩔 수 없이 전투를 준비합니다. 냉정이 1 하락합니다.");
                            Console.ResetColor();
                            Console.WriteLine();
                            Wait(10);
                            data.COL--;
                            GoNext();
                            data.scene = Scene.Battle1;
                        }
                        break;
                    case 2:
                        if (RandomSuccess((data.TEC)))
                        {
                            Wait(10);
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("당신은 보안 패널을 성공적으로 해킹했습니다.");
                            Wait(15);
                            Console.WriteLine("보안요원이 보안 패널을 믿고 한 눈 파는 사이 몰래 다음 장소로 지나갔습니다.");
                            Wait(15);
                            Console.WriteLine("기술이 1 상승했습니다.");
                            Console.ResetColor();
                            Console.WriteLine();
                            Wait(10);
                            data.TEC++;
                            GoNext();
                            data.scene = Scene.Security;
                        }
                        else
                        {
                            Wait(10);
                            Console.WriteLine();
                            Console.WriteLine("당신이 해킹을 시도하자 마자 보안장치가 작동합니다.");
                            Wait(15);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("침입자 감지! 침입자 감지! 침입자 감지!");
                            Console.ResetColor();
                            Wait(15);
                            Console.WriteLine("보안요원이 달려오고 당신은 전투를 준비합니다. 기술이 1 하락합니다.");
                            Console.WriteLine();
                            data.TEC--;
                            Wait(10);
                            GoNext();
                            data.scene = Scene.Battle1;
                        }
                        break;
                    case 3:
                        Wait(10);
                        Console.WriteLine();
                        Console.WriteLine("당신은 곧바로 전투를 준비합니다.");
                        Wait(15);
                        Console.WriteLine("주저하지 않고 전투를 준비한 당신은 힘이 1 증가합니다.");
                        Wait(10);
                        Console.WriteLine();
                        data.STR++;
                        GoNext();
                        data.scene = Scene.Battle1;
                        break;
                                            default:
                        {
                            Console.WriteLine("잘못 입력했습니다.");
                            Wait(10);
                        }
                        break;

                }
            }
        }
        #endregion

        #region 보안요원과의 전투
        static void Battle1Scene()
        {
            Enemy enemy = new Enemy();
            {
                enemy.name = "아라사카 보안요원";
                enemy.description = "그리 강해보이지는 않습니다.";
                enemy.damage = 5;
                enemy.enemyMaxHp = 38;
                enemy.enemyCurHp = 38;
            }
            Wait(10);
            Console.WriteLine("=======================================================================");
            Console.WriteLine($"{enemy.name}은 전투를 준비합니다.{enemy.description}");
            Console.WriteLine($"{enemy.name}의 최대 체력은 {enemy.enemyMaxHp}입니다.");
            Console.WriteLine("=======================================================================");
            Console.WriteLine();
            Wait(10);

            while (enemy.enemyCurHp > 0)
            {
                Console.WriteLine("1. (힘) 공격하기");
                Console.WriteLine("2. (기술) 해킹하기");
                Console.Write("선택 - ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        {
                            int damage = RandomDamage(data.STR);
                            enemy.enemyCurHp -= damage;
                            Console.WriteLine();
                            Console.WriteLine($"당신은 {enemy.name}에게 {damage}만큼의 데미지를 주었습니다.");
                            Console.WriteLine($"{enemy.name}의 현재 체력은 {enemy.enemyCurHp}입니다.");
                            Console.WriteLine();
                            Wait(10);

                        }
                        break;
                    case "2":
                        {
                            if (RandomSuccess(data.TEC))
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("당신은 해킹에 성공했습니다.");
                                enemy.damage /= 2;
                                Console.WriteLine($"{enemy.name}의 데미지가 {enemy.damage}로 줄어들었습니다.");
                                Console.ResetColor();
                                Console.WriteLine();
                                Wait(10);

                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("당신은 해킹에 실패했습니다..");
                                Console.WriteLine($"{enemy.name}이 공격을 시도합니다.");
                                Console.ResetColor();
                                Console.WriteLine();
                                Wait(10);

                            }

                        }
                        break;
                    default:
                        Console.WriteLine("잘못된 선택입니다.");
                        break;
                }

                if (enemy.enemyCurHp > 0)
                {
                    data.curHp -= enemy.damage;
                    Console.WriteLine($"적이 공격하여 {enemy.damage}만큼의 데미지를 주었습니다.");
                    Console.WriteLine();
                    Wait(10);

                }

                Console.WriteLine($"당신의 체력은 {data.curHp}입니다.");
                Console.WriteLine($"{enemy.name}의 체력은 {enemy.enemyCurHp}입니다.");
                Console.WriteLine();
                Wait(10);

                if (data.curHp <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("당신은 전투에서 패배했습니다..");
                    data.running = false;
                    Console.ResetColor();
                    Wait(10);
                    return;
                }

                if (enemy.enemyCurHp <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Wait(10);
                    Console.WriteLine("당신은 전투에서 승리했습니다!");
                    Wait(10);
                    Console.WriteLine("모든 스탯이 1 상승합니다!");
                    Wait(10);
                    Console.WriteLine("승리한 후, 휴식을 취해 모든 체력을 회복합니다.");
                    Wait(10);
                    Console.WriteLine();
                    Console.ResetColor();
                    data.STR++;
                    data.TEC++;
                    data.RFX++;
                    data.INT++;
                    data.COL++;
                    data.curHp = data.maxHp;
                    GoNext();
                    data.scene = Scene.Security;
                }

            }
        }
        #endregion

        #region 아무도 없는 방
        static void SecurityScene()
        {
            PrintProfile();
            Wait(15);
            Console.WriteLine("당신은 보안요원이 있는 입구를 지나 아무도 없는 방에 도달했습니다");
            Wait(15);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("이윽고 당신의 눈에 들어온 것은 수많은 보안장치들입니다.");
            Console.ResetColor();
            Wait(15);

            if (data.lifepath == Lifepath.Nomad)
            {
                Console.WriteLine();
                Console.WriteLine("온갖 기계와 기술들에 박식한 노마드출신인 당신은 높은 확률로 보안장치를 해제할 수 있을 것 같습니다.");
                Console.WriteLine("(맥가이버 칼 소모)");
                Console.WriteLine();
                Wait(15);
                Console.Write("시도하시려면 y, 전투를 실행하시려면 n을 입력해주세요 - ");
                Wait(15);
                string input = Console.ReadLine();

                switch (input)
                {
                    case "Y":
                    case "y":
                        if (RandomSuccess(9))
                        {
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("당신은 알고있는 지식을 총 동원해서 보안장치를 해제했습니다.");
                            Wait(15);
                            Console.WriteLine("당신은 방을 무사히 통과했습니다.");
                            Wait(15);
                            Console.ResetColor();
                            Console.WriteLine("노마드의 맥가이버 칼을 소모했습니다.");
                            data.memento = Memento.Empty;
                            Wait(10);
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("다음 방에 들어서자 아라사카에서 가장 강한 아담 스매셔가 눈에 들어옵니다.");
                            Console.ResetColor();
                            Console.WriteLine();
                            GoNext();
                            data.scene = Scene.Boss;
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("당신은 보안장치의 해제를 시도했지만 손이 삐끗했습니다..");
                            Wait(15);
                            Console.WriteLine("경보를 들은 아라사카의 경찰이 바로 출동했습니다.");
                            Wait(15);
                            Console.ResetColor();
                            Console.WriteLine("노마드의 맥가이버 칼만 소모했습니다.");
                            Console.WriteLine();
                            data.memento = Memento.Empty;
                            Wait(10);
                            GoNext();
                            data.scene = Scene.Battle2;
                        }
                        break;
                    case "N":
                    case "n":
                        {
                            Console.WriteLine();
                            Console.WriteLine("당신은 곱게 지나갈 생각이 없습니다.");
                            Wait(15);
                            Console.WriteLine("그냥 보안장치를 울려버리자, 경찰이 출동합니다.");
                            Wait(10);
                            GoNext();
                            data.scene = Scene.Battle2;
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("잘못 입력했습니다.");
                            Wait(10);
                        }
                        break;

                }

            }

            else
            {
                Console.WriteLine();
                Console.WriteLine("당신의 머릿속에는 방을 무사히 지나갈 몇가지 방법이 떠오릅니다.");
                Wait(5);
                Console.WriteLine();
                Console.WriteLine("=======================================================================");
                Console.WriteLine("1. (지능) 보안패널의 암호를 해독해본다.");
                Wait(3);
                Console.WriteLine("2. (반사신경) 스파이 영화에서 본것들을 떠올리며 보안장치를 다 회피한다.");
                Wait(3);
                Console.WriteLine("3. 그딴건 없다. 보안장치를 울리자.");
                Console.WriteLine("=======================================================================");
                Console.WriteLine();
                Console.Write("선택지를 입력해주세요 - ");
                int select;

                bool success = int.TryParse(Console.ReadLine(), out select);


                if (success == false)
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Wait(5);
                    return;
                }
                else if (select <= 0 || select >= 4)
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Wait(5);
                    return;
                }

                switch (select)
                {
                    case 1:
                        if (RandomSuccess((data.INT)))
                        {
                            Wait(10);
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("보안패널의 암호는 생각보다 쉬웠습니다.");
                            Wait(15);
                            Console.WriteLine("보안장치들을 모두 해제하고 다음 방으로 가는 문을 열었습니다.");
                            Wait(15);
                            Console.WriteLine("지능이 1 상승했습니다.");
                            Console.ResetColor();
                            data.INT++;
                            Console.WriteLine();
                            Wait(15);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("다음 방에 들어서자 아라사카에서 가장 강한 아담 스매셔가 눈에 들어옵니다.");
                            Wait(10);
                            Console.ResetColor();
                            Console.WriteLine();
                            GoNext();
                            data.scene = Scene.Boss;
                        }
                        else
                        {
                            Wait(10);
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("생각보다 암호가 어렵습니다.. 보안장치가 울립니다.");
                            Wait(15);
                            Console.WriteLine("아라사카의 경찰이 출동했고 전투를 준비합니다. 지능이 1 하락합니다.");
                            Console.WriteLine();
                            Console.ResetColor();
                            Wait(10);
                            data.INT--;
                            GoNext();
                            data.scene = Scene.Battle2;
                        }
                        break;
                    case 2:
                        if (RandomSuccess((data.RFX)))
                        {
                            Wait(10);
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("당신은 제임스 본드처럼 모든 레이저들을 회피했습니다.");
                            Wait(15);
                            Console.WriteLine("다음 방앞에 왔고, 다음 방에 들어서자 아라사카에서 가장 강한 아담 스매셔가 눈에 들어옵니다.");
                            Wait(15);
                            Console.WriteLine("반사신경이 1 상승했습니다.");
                            Console.ResetColor();
                            Console.WriteLine();
                            Wait(10);
                            data.RFX++;
                            GoNext();
                            data.scene = Scene.Boss;
                        }
                        else
                        {
                            Wait(10);
                            Console.WriteLine();
                            Console.WriteLine("당신의 다리가 레이저에 걸려버렸습니다..");
                            Wait(15);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("침입자 감지! 침입자 감지! 침입자 감지!");
                            Console.ResetColor();
                            Wait(15);
                            Console.WriteLine("아라사카 경찰이 달려오고 당신은 전투를 준비합니다. 반사신경이 1 하락합니다.");
                            data.RFX--;
                            Wait(10);
                            Console.WriteLine();
                            GoNext();
                            data.scene = Scene.Battle2;
                        }
                        break;
                    case 3:
                        Wait(10);
                        Console.WriteLine();
                        Console.WriteLine("당신은 곧바로 경보장치를 울렸고, 아라사카의 경찰이 달려옵니다.");
                        Wait(15);
                        Console.WriteLine("주저하지 않고 전투를 준비한 당신은 힘이 1 증가합니다.");
                        Wait(10);
                        data.STR++;
                        Console.WriteLine();
                        GoNext();
                        data.scene = Scene.Battle2;
                        break;
                    default:
                        {
                            Console.WriteLine("잘못 입력했습니다.");
                            Wait(10);
                        }
                        break;
                }
            }
        }
        #endregion

        #region 경찰과의 전투
        static void Battle2Scene()
        {
            Enemy enemy = new Enemy();
            {
                enemy.name = "아라사카 경찰";
                enemy.description = "전투에 능숙해 보입니다.";
                enemy.damage = 10;
                enemy.enemyMaxHp = 70;
                enemy.enemyCurHp = 70;
            }
            Wait(10);
            Console.WriteLine("=======================================================================");
            Console.WriteLine($"{enemy.name}은 전투를 준비합니다.{enemy.description}");
            Console.WriteLine($"{enemy.name}의 최대 체력은 {enemy.enemyMaxHp}입니다.");
            Console.WriteLine("=======================================================================");
            Console.WriteLine();
            Wait(10);

            while (enemy.enemyCurHp > 0)
            {
                Console.WriteLine("1. (힘) 공격하기");
                Console.WriteLine("2. (기술) 해킹하기");
                Console.Write("선택 - ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        {
                            int damage = RandomDamage(data.STR);
                            enemy.enemyCurHp -= damage;
                            Console.WriteLine();
                            Console.WriteLine($"당신은 {enemy.name}에게 {damage}만큼의 데미지를 주었습니다.");
                            Console.WriteLine($"{enemy.name}의 현재 체력은 {enemy.enemyCurHp}입니다.");
                            Console.WriteLine();
                            Wait(10);
                        }
                        break;
                    case "2":
                        {
                            if (RandomSuccess(data.TEC))
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("당신은 해킹에 성공했습니다.");
                                enemy.damage /= 2;
                                Console.WriteLine($"{enemy.name}의 데미지가 {enemy.damage}로 줄어들었습니다.");
                                Console.ResetColor();
                                Console.WriteLine();
                                Wait(10);
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("당신은 해킹에 실패했습니다..");
                                Console.WriteLine($"{enemy.name}이 공격을 시도합니다.");
                                Console.ResetColor();
                                Console.WriteLine();
                                Wait(10);
                            }

                        }
                        break;
                    default:
                        Console.WriteLine("잘못된 선택입니다.");
                        break;
                }

                if (enemy.enemyCurHp > 0)
                {
                    data.curHp -= enemy.damage;
                    Console.WriteLine($"적이 공격하여 {enemy.damage}만큼의 데미지를 주었습니다.");
                    Console.WriteLine();
                    Wait(10);
                }

                Console.WriteLine($"당신의 체력은 {data.curHp}입니다.");
                Console.WriteLine($"{enemy.name}의 체력은 {enemy.enemyCurHp}입니다.");
                Console.WriteLine();
                Wait(10);

                if (data.curHp <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("당신은 전투에서 패배했습니다..");
                    data.running = false;
                    Console.ResetColor();
                    Wait(10);
                    return;
                }

                if (enemy.enemyCurHp <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Wait(10);
                    Console.WriteLine("당신은 전투에서 승리했습니다!");
                    Wait(10);
                    Console.WriteLine("모든 스탯이 1 상승합니다!");
                    Wait(10);
                    Console.WriteLine("승리한 후, 휴식을 취해 모든 체력을 회복합니다.");
                    Wait(10);
                    Console.ResetColor();
                    Console.WriteLine();
                    data.STR++;
                    data.TEC++;
                    data.RFX++;
                    data.INT++;
                    data.COL++;
                    data.curHp = data.maxHp;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("다음 방에 들어서자 아라사카에서 가장 강한 아담 스매셔가 눈에 들어옵니다.");
                    Console.ResetColor();
                    GoNext();
                    data.scene = Scene.Boss;
                }

            }
        }
        #endregion

        #region 보스와의 전투
        static void BossScene()
        {
            Enemy enemy = new Enemy();
            {
                enemy.name = "아담 스매셔";
                enemy.description = "위압감이 넘칩니다. 중무장을 하고 있습니다.";
                enemy.damage = 15;
                enemy.enemyMaxHp = 85;
                enemy.enemyCurHp = 85;
            }
            Wait(10);
            Console.WriteLine("=======================================================================");
            Console.WriteLine($"{enemy.name}는 전투를 준비합니다.{enemy.description}");
            Console.WriteLine($"{enemy.name}의 최대 체력은 {enemy.enemyMaxHp}입니다.");
            Console.WriteLine("=======================================================================");
            Console.WriteLine();
            Wait(10);

            while (enemy.enemyCurHp > 0)
            {
                Console.WriteLine("1. (힘) 공격하기");
                Console.WriteLine("2. (기술) 해킹하기");
                Console.Write("선택 - ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        {
                            int damage = RandomDamage(data.STR);
                            enemy.enemyCurHp -= damage;
                            Console.WriteLine();
                            Console.WriteLine($"당신은 {enemy.name}에게 {damage}만큼의 데미지를 주었습니다.");
                            Console.WriteLine($"{enemy.name}의 현재 체력은 {enemy.enemyCurHp}입니다.");
                            Console.WriteLine();
                            Wait(10);

                        }
                        break;
                    case "2":
                        {
                            if (RandomSuccess(data.TEC))
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("당신은 해킹에 성공했습니다.");
                                enemy.damage /= 2;
                                Console.WriteLine($"{enemy.name}의 데미지가 {enemy.damage}로 줄어들었습니다.");
                                Console.WriteLine();
                                Console.ResetColor();
                                Wait(10);
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("당신은 해킹에 실패했습니다..");
                                Console.WriteLine($"{enemy.name}이 공격을 시도합니다.");
                                Console.ResetColor();
                                Console.WriteLine();
                                Wait(10);
                            }

                        }
                        break;
                    default:
                        Console.WriteLine("잘못된 선택입니다.");
                        break;
                }

                if (enemy.enemyCurHp > 0)
                {
                    data.curHp -= enemy.damage;
                    Console.WriteLine($"적이 공격하여 {enemy.damage}만큼의 데미지를 주었습니다.");
                    Console.WriteLine();
                    Wait(10);
                }

                Console.WriteLine($"당신의 체력은 {data.curHp}입니다.");
                Console.WriteLine($"{enemy.name}의 체력은 {enemy.enemyCurHp}입니다.");
                Console.WriteLine();
                Wait(10);

                if (data.curHp <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("당신은 전투에서 패배했습니다..");
                    Console.ResetColor();
                    data.running = false;
                    Wait(10);
                    return;
                }

                if (enemy.enemyCurHp <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Wait(10);
                    Console.WriteLine("당신은 전투에서 승리했습니다!");
                    Wait(10);
                    Console.WriteLine();
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("당신은 마지막 방으로 들어섭니다.");
                    Wait(10);
                    Console.WriteLine("가장 강력한 보스가 지키고 있던 방은, 당신의 목적인 문서가 있던 방이였습니다.");
                    Console.ResetColor();
                    Wait(10);
                    GoNext();
                    data.scene = Scene.Ending;
                }
            }
        }
        #endregion

        #region 문서가 있는 방
        static void EndingScene()
        {
            Wait(10);
            Console.WriteLine("아담 스매셔와의 전투에서 힘겹게 승리한 당신은 지친 몸을 이끌고");
            Wait(10);
            Console.WriteLine("아담 스매셔가 지키고 있던 방에 들어섰습니다.");
            Console.WriteLine();
            Wait(10);
            Console.WriteLine("방 한가운데는 덩그러니 책상 하나만 놓여있었고,");
            Wait(10);
            Console.WriteLine("책상 위에 있는 문서는 당신이 이곳에 온 이유인");
            Console.ForegroundColor = ConsoleColor.Green;
            Wait(10);
            Console.WriteLine("고객의 명부가 있습니다");
            Console.ResetColor();
            Console.WriteLine();
            Wait(10);
            Console.WriteLine("당신은 고객의 명부속 내용을 쓱 훑어봅니다.");
            Wait(10);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("명부는 할렘가 재개발에 관한 문서입니다.");
            Wait(10);
            Console.WriteLine("그중에서도 재개발에 반대하는 길거리 부랑자들의 암살 명단입니다.");
            Console.ResetColor();

            if (data.lifepath == Lifepath.Corpo)
            {
                Wait(20);
                Console.WriteLine();
                Console.WriteLine("대기업의 엘리트 출신으로 자라온 당신은");
                Wait(10);
                Console.WriteLine("이런 일이 암암리에 빈번하게 발생한다는 사실을 잘 알고있습니다.");
                Console.WriteLine();
                Wait(10);
                Console.WriteLine("뭐..그 사람들이 어떻게 되든 당신의 알빠는 아닙니다.");
                Wait(10);
                Console.WriteLine("당신은 임무를 결국 완수했고, 그게 중요한거니까요.");
                Console.WriteLine();
                Wait(10);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"축하합니다! {data.name}은 무사히 문서를 회수했고,");
                Wait(10);
                Console.WriteLine("애프터나이트에 연락해 돌아갈 우주선을 호출했습니다!");
                Wait(10);
                Console.WriteLine("Normal Ending");
                Console.ResetColor();
                Wait(10);
                Console.WriteLine("게임을 종료하시려면 아무키나 입력해주세요.");
                Console.ReadKey(true);
                Environment.Exit(0);
            }

            if (data.lifepath == Lifepath.Nomad)
            {
                Wait(20);
                Console.WriteLine();
                Console.WriteLine("집시처럼 떠도는 인생을 자라온 당신은");
                Wait(10);
                Console.WriteLine("할렘가고 나발이고 도시 내부의 일에는 관심이 없습니다.");
                Console.WriteLine();
                Wait(10);
                Console.WriteLine("저런 일이 일어난다 한들, 노마드들에게는 아무런 이득도 손해도 없으니까요.");
                Wait(10);
                Console.WriteLine("당신은 임무를 결국 완수했고, 그게 중요한거죠.");
                Console.WriteLine();
                Wait(10);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"축하합니다! {data.name}은 무사히 문서를 회수했고,");
                Wait(10);
                Console.WriteLine("애프터나이트에 연락해 돌아갈 우주선을 호출했습니다!");
                Wait(10);
                Console.WriteLine("Normal Ending");
                Console.ResetColor();
                Wait(10);
                Console.WriteLine("게임을 종료하시려면 아무키나 입력해주세요.");
                Console.ReadKey(true);
                Environment.Exit(0);
            }

            if (data.lifepath == Lifepath.StreetKid)
            {
                Wait(20);
                Console.WriteLine();
                Console.WriteLine("군데군데 아는 이름들이 눈에 띕니다.");
                Console.WriteLine();
                Wait(10);
                Console.WriteLine("수도 없이 싸웠던 뒷골목 양아치들부터");
                Wait(10);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("당신의 가족, 친척 친구들까지..");
                Console.WriteLine();
                Wait(10);
                Console.ResetColor();
                Console.WriteLine("만약, 임무를 완수한다면 거금을 얻게 되지만,");
                Wait(10);
                Console.WriteLine("문서에 올라있는 당신의 지인들은 암살당할 것입니다.");
                Wait(10);
                Console.WriteLine();
                Console.WriteLine("부랑자로 자라 특별한 소지품도 없이 힘들게 임무를 완수한 당신은,");
                Wait(10);
                Console.WriteLine("이 자리에 오기까지의 노력이 스쳐지나갑니다.");
                Console.WriteLine();
                Wait(10);
                Console.Write("임무를 완수하려면 Y, 완수하지 않으시려면 N을 눌러주세요. - ");
                Wait(20);
                string input = Console.ReadLine();

                switch (input)
                {
                    case "Y":
                    case "y":
                        {
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"축하합니다! {data.name}은 무사히 문서를 회수했고,");
                            Wait(10);
                            Console.WriteLine("애프터나이트에 연락해 돌아갈 우주선을 호출했습니다!");
                            Wait(10);
                            Console.WriteLine("Normal Ending");
                            Console.ResetColor();
                            Wait(10);
                            Console.WriteLine("게임을 종료하시려면 아무키나 입력해주세요.");
                            Console.ReadKey(true);
                            Environment.Exit(0);
                        }
                        break;
                    case "N":
                    case "n":
                        {
                            Console.WriteLine();
                            Console.WriteLine("당신은 거금에 가족, 친구, 친척들을 팔 수는 없습니다.");
                            Wait(10);
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("당신은 문서에 불을 붙였습니다.");
                            Console.ResetColor();
                            Wait(10);
                            Console.WriteLine();
                            Console.WriteLine($"이제 {data.name}은 애프터나이트로 돌아가서,");
                            Wait(10);
                            Console.WriteLine("의뢰인이 누군지 알아보고 대책을 세워야 합니다.");
                            Console.WriteLine();
                            Wait(10);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("True Ending");
                            Console.ResetColor();
                            Wait(10);
                            Console.WriteLine("게임을 종료하시려면 아무키나 입력해주세요.");
                            Console.ReadKey(true);
                            Environment.Exit(0);

                        }
                        break;
                    default:
                        {
                            Console.WriteLine("잘못 입력했습니다.");
                            Wait(10);
                        }
                        break;


                }
            }
        }
        #endregion
    }
}