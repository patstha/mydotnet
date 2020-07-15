using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;



class Result
{

    /*
     * Complete the 'fetchItemsToDisplay' function below.
     *
     * The function is expected to return a STRING_ARRAY.
     * The function accepts following parameters:
     *  1. 2D_STRING_ARRAY items
     *  2. INTEGER sortParameter
     *  3. INTEGER sortOrder
     *  4. INTEGER itemsPerPage
     *  5. INTEGER pageNumber
     */

    public static List<string> fetchItemsToDisplay(List<List<string>> items, int sortParameter, int sortOrder, int itemsPerPage, int pageNumber)
    {
        foreach (var x in items)
        {
            foreach (var y in x)
            {
                Console.Write(y);
                Console.Write(" ");
            }
            Console.WriteLine();
        }
        Console.WriteLine($"{items.Count}");
        Console.WriteLine($"{sortParameter}");
        Console.WriteLine($"{sortOrder}");
        Console.WriteLine($"{itemsPerPage}");
        Console.WriteLine($"{pageNumber}");
        IEnumerable < List<string> > orderedItems;
        if (sortOrder == 0)
        {
            orderedItems = items.OrderBy(x => x[sortParameter]);
        }
        else
        {
            orderedItems = items.OrderByDescending(x => x[sortParameter]);
        }
        IEnumerable<List<string>> filteredItems = orderedItems.Skip(pageNumber * itemsPerPage).Take(itemsPerPage);
        List<string> result = new List<string>();
        foreach (var item in filteredItems)
        {
            result.Add(item[0]);
        }
        return result;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter("potato.txt", true);

        // int itemsRows = 2;
        // int itemsColumns = 3;

        List<List<string>> items = new List<List<string>>();

        // for (int i = 0; i < itemsRows; i++)
        // {
        //     items.Add(Console.ReadLine().TrimEnd().Split(' ').ToList());
        // }

        // items.Add("p1 1 2".Split(' ').ToList());
        // items.Add("p2 2 1".Split(' ').ToList());

        // int sortParameter = 0;

        // int sortOrder = 0;

        // int itemsPerPage = 1;

        // int pageNumber = 0;

        // items.Add("owjevtkuyv 58584272 62930912".Split(' ').ToList());
        // items.Add("rpaqgbjxik 9425650 96088250".Split(' ').ToList());
        // items.Add("dfbkasyqcn 37469674 46363902".Split(' ').ToList());
        // items.Add("vjrrisdfxe 18666489 88046739".Split(' ').ToList());

        // int sortParameter = 2;

        // int sortOrder = 1;

        // int itemsPerPage = 2;

        // int pageNumber = 1;

        items.Add("quhvvyzguh 61533914 99331900".Split(' ').ToList());
        items.Add("zzzkafeqca 84330308 93258114".Split(' ').ToList());
        items.Add("kxyiptrcll 13305462 76068413".Split(' ').ToList());
        items.Add("jdlkwabtqs 38447326 9799445".Split(' ').ToList());
        items.Add("vwlijufnoq 7559571 65457601".Split(' ').ToList());
        items.Add("jnremeoydw 68065837 49923498".Split(' ').ToList());
        items.Add("zidayltdni 26130579 28450774".Split(' ').ToList());
        items.Add("pjvlcjzbvs 60555617 20169709".Split(' ').ToList());
        items.Add("qucprezgkn 87090952 11038923".Split(' ').ToList());
        items.Add("ymvnoybqbl 66898413 29055332".Split(' ').ToList());
        items.Add("qevlotuqjh 30019287 44663032".Split(' ').ToList());
        items.Add("ntmqjmyqdh 87495145 52087467".Split(' ').ToList());
        items.Add("asdqdzkwpx 95351655 62237189".Split(' ').ToList());
        items.Add("bmklmtzchx 41881393 73419582".Split(' ').ToList());
        items.Add("wwiurugkdt 49279838 93734414".Split(' ').ToList());
        items.Add("oowynjovcf 67811229 82487824".Split(' ').ToList());
        items.Add("wgdojpdwoi 32736587 49379499".Split(' ').ToList());
        items.Add("drflczdqzj 22431161 29358211".Split(' ').ToList());
        items.Add("sieqtxrtvl 67156733 79182989".Split(' ').ToList());
        items.Add("jxjhunmjfq 78016557 55738118".Split(' ').ToList());
        items.Add("ohiyrrcueo 69041744 43422028".Split(' ').ToList());
        items.Add("mtqbgyjurq 7430196 1437536".Split(' ').ToList());
        items.Add("swvzqvkxzi 95401982 94800101".Split(' ').ToList());
        items.Add("zoftrlxost 85857591 4407286".Split(' ').ToList());
        items.Add("pjibnkcaiu 84850923 28109299".Split(' ').ToList());
        items.Add("gouhhanglk 13848330 50725099".Split(' ').ToList());
        items.Add("afumzkvyqb 11021443 51663570".Split(' ').ToList());
        items.Add("zltxjklect 18052106 28231136".Split(' ').ToList());
        items.Add("bijlrdbuts 48201930 45296279".Split(' ').ToList());
        items.Add("wimdrdhjzi 21165432 42994933".Split(' ').ToList());
        items.Add("yrtopsjsty 42197053 37641683".Split(' ').ToList());
        items.Add("cxxfcbwtdc 67366164 97101090".Split(' ').ToList());
        items.Add("ogvkliopxt 88194034 89597898".Split(' ').ToList());
        items.Add("ryeikgemxe 11810432 29435100".Split(' ').ToList());
        items.Add("qdsncjruuh 93422723 34627371".Split(' ').ToList());
        items.Add("znucwwppqw 42903992 18845308".Split(' ').ToList());
        items.Add("qrdevqylcz 16711020 89239030".Split(' ').ToList());
        items.Add("otblvxvhpy 20242181 12805974".Split(' ').ToList());
        items.Add("jsasuwlwoa 72877466 83756983".Split(' ').ToList());
        items.Add("rdwxqzgfst 40913844 33676935".Split(' ').ToList());
        items.Add("eltxtmgrrs 16189194 22127013".Split(' ').ToList());
        items.Add("rbfnpixtem 79475183 73735715".Split(' ').ToList());
        items.Add("qptqgetpqa 54333291 87164307".Split(' ').ToList());
        items.Add("pppcokntvp 59971890 94518475".Split(' ').ToList());
        items.Add("sugwomaulo 54917862 43794337".Split(' ').ToList());
        items.Add("toxzwjtruc 41174373 13909833".Split(' ').ToList());
        items.Add("tipbltyguu 49281156 20772173".Split(' ').ToList());
        items.Add("ckpodsobrw 94249745 2000596".Split(' ').ToList());
        items.Add("ghbicxhoef 42240479 8111263".Split(' ').ToList());
        items.Add("ipddsfczyv 84673797 3522397".Split(' ').ToList());
        items.Add("omosbcgwvq 61677428 42208230".Split(' ').ToList());
        items.Add("xqlnxunovg 81353037 88985812".Split(' ').ToList());
        items.Add("djdwopxzfw 8123774 54572123".Split(' ').ToList());
        items.Add("yezmxfojhi 32383758 73740992".Split(' ').ToList());
        items.Add("acvuwzlqgh 92500109 55753269".Split(' ').ToList());
        items.Add("szlbfhqowa 31304428 93006459".Split(' ').ToList());
        items.Add("tuddaxwhmi 50929232 62089296".Split(' ').ToList());
        items.Add("oogxzuxexd 16563624 18216013".Split(' ').ToList());
        items.Add("dlrmqbhizy 80440654 28934480".Split(' ').ToList());
        items.Add("tmsosfmdgp 92938735 9104620".Split(' ').ToList());
        items.Add("ncwgndhrxx 83693911 97653883".Split(' ').ToList());
        items.Add("dgkiucshtp 7202662 92545291".Split(' ').ToList());
        items.Add("gwrteypxmg 86877428 41123459".Split(' ').ToList());
        items.Add("yhwyayilxp 35600632 77841667".Split(' ').ToList());
        items.Add("mfehycifnx 42616415 38521743".Split(' ').ToList());
        items.Add("mgeeuewnpo 11441172 7717441".Split(' ').ToList());
        items.Add("ifkflzxrkv 31522750 30278932".Split(' ').ToList());
        items.Add("ranhpajqvd 35273182 98671348".Split(' ').ToList());
        items.Add("zwurtaakaq 28847095 74495622".Split(' ').ToList());
        items.Add("xluiwjuygg 24399639 79633431".Split(' ').ToList());
        items.Add("qlcuohgrty 50800870 87915474".Split(' ').ToList());
        items.Add("vgagflkygo 2968806 77272740".Split(' ').ToList());
        items.Add("bvjsxyikst 50800683 72865010".Split(' ').ToList());
        items.Add("xizfwmrrsd 10125432 16395378".Split(' ').ToList());
        items.Add("hfckpfbqle 51887449 90483950".Split(' ').ToList());
        items.Add("xollodspaj 79866813 57529693".Split(' ').ToList());
        items.Add("zwdyvplcxh 42117212 55145198".Split(' ').ToList());
        items.Add("jntprpzjud 74979414 95578176".Split(' ').ToList());
        items.Add("edyhosnjnr 47666139 77675177".Split(' ').ToList());
        items.Add("amkvusadgz 95294723 71793689".Split(' ').ToList());
        items.Add("dfevbytedp 68569659 87116466".Split(' ').ToList());
        items.Add("pqzhkwvlzm 87083116 87736115".Split(' ').ToList());
        items.Add("rylesyymmd 36666699 17495849".Split(' ').ToList());
        items.Add("veuhdavnpo 94876309 61656133".Split(' ').ToList());
        items.Add("fhjghiruhs 96079292 74518412".Split(' ').ToList());
        items.Add("ncoaisulgv 11588297 21056114".Split(' ').ToList());
        items.Add("pzuoaoqbun 6908004 28174157".Split(' ').ToList());
        items.Add("zvsiiqnjky 26159524 21950811".Split(' ').ToList());
        items.Add("qnrwiqygnx 55677581 58326220".Split(' ').ToList());
        items.Add("ibqgnrwynj 64216578 64518629".Split(' ').ToList());
        items.Add("pyhaiifpuo 28557673 76446119".Split(' ').ToList());
        items.Add("khqpegncfj 15070369 70578593".Split(' ').ToList());
        items.Add("gaqlqgrkzu 33043505 24690586".Split(' ').ToList());
        items.Add("jrjsfwyhhe 36939463 28552924".Split(' ').ToList());
        items.Add("rhedywxyis 57181816 37988147".Split(' ').ToList());
        items.Add("ejvfhhmbjm 75942939 67689455".Split(' ').ToList());
        items.Add("tvsjmszucw 45886700 69002338".Split(' ').ToList());
        items.Add("laennjrkha 66929016 80498040".Split(' ').ToList());
        items.Add("nvhzvohfrv 45275450 65353777".Split(' ').ToList());
        items.Add("supmkpksgk 70019876 95995954".Split(' ').ToList());
        items.Add("tnxlxwcfad 69841766 4489900".Split(' ').ToList());
        items.Add("bgpcgfueco 34460858 52523583".Split(' ').ToList());
        items.Add("jpmiqwznnu 24305693 69846477".Split(' ').ToList());
        items.Add("wsnddazebu 31281552 63034596".Split(' ').ToList());
        items.Add("gjjefotdgi 42229030 70192989".Split(' ').ToList());
        items.Add("tucqpyabql 72440105 58687909".Split(' ').ToList());
        items.Add("fsiviwnqpz 27632044 55295756".Split(' ').ToList());
        items.Add("frghlitapu 1580468 13426311".Split(' ').ToList());
        items.Add("muxvsenkvu 46872194 10346600".Split(' ').ToList());
        items.Add("vxhonxjqvb 42816898 97653964".Split(' ').ToList());
        items.Add("xakjibtpzw 52639902 19847685".Split(' ').ToList());
        items.Add("vbnxjzuhsa 51382880 12034910".Split(' ').ToList());
        items.Add("cuikzirlxe 81384260 67642548".Split(' ').ToList());
        items.Add("fhdzmfhqzz 74879775 34841774".Split(' ').ToList());
        items.Add("fqucilyajs 86383151 11836953".Split(' ').ToList());
        items.Add("fsijpquzya 8011194 30228109".Split(' ').ToList());
        items.Add("ialrbpbbhb 1599891 17428984".Split(' ').ToList());
        items.Add("lljgelxpyb 46913102 6284200".Split(' ').ToList());
        items.Add("mydyqwtbci 39525198 20534441".Split(' ').ToList());
        items.Add("vwpzxfrkxb 39475341 37092911".Split(' ').ToList());
        items.Add("kiquwymyft 76957979 52483692".Split(' ').ToList());
        items.Add("dvuppxkmoc 50399378 71958238".Split(' ').ToList());
        items.Add("quemokvdix 9352627 23295758".Split(' ').ToList());
        items.Add("azddtocgzd 57662626 1701408".Split(' ').ToList());
        items.Add("gxbmnvitmf 35896264 58582819".Split(' ').ToList());
        items.Add("jmiwlybiwz 13381647 83835529".Split(' ').ToList());
        items.Add("csxlesezax 70327312 84899200".Split(' ').ToList());
        items.Add("isqtzlvpum 13453736 12229040".Split(' ').ToList());
        items.Add("wdsiwpcroa 84097601 60325171".Split(' ').ToList());
        items.Add("iwyxepmbxv 70567472 17904182".Split(' ').ToList());
        items.Add("rgflggozfm 5796479 90919993".Split(' ').ToList());
        items.Add("encwvjowoq 35556986 31000368".Split(' ').ToList());
        items.Add("gllcotwgav 40206785 58853314".Split(' ').ToList());
        items.Add("ruegnewncq 43036588 83108945".Split(' ').ToList());
        items.Add("wgnwluylff 44845657 18474437".Split(' ').ToList());
        items.Add("atjtwawkvh 9072428 98426326".Split(' ').ToList());
        items.Add("tckmgfgajz 88149145 48431452".Split(' ').ToList());
        items.Add("wtowihpdgo 26756376 46514099".Split(' ').ToList());
        items.Add("biaxaxmweo 42937584 78539919".Split(' ').ToList());
        items.Add("sxwoypnxtx 63125250 70226155".Split(' ').ToList());
        items.Add("nrsxeqlufx 66150952 80081430".Split(' ').ToList());
        items.Add("zxvxdznnhr 26208240 47742045".Split(' ').ToList());
        items.Add("tnyncujhfe 16672364 78021147".Split(' ').ToList());
        items.Add("shzgvbxgql 58546686 32598432".Split(' ').ToList());
        items.Add("xvpwxextnq 4513593 2916039".Split(' ').ToList());
        items.Add("xrvyxtodbi 22241288 56945104".Split(' ').ToList());
        items.Add("ulijmkasju 27295972 74575125".Split(' ').ToList());
        items.Add("bnttpzfkrx 8821657 90592978".Split(' ').ToList());
        items.Add("uydoxiryha 38334193 47459917".Split(' ').ToList());
        items.Add("wknxfbgrym 38401351 76184423".Split(' ').ToList());
        items.Add("eppjyotqwf 62628120 13293677".Split(' ').ToList());
        items.Add("cyhcpssrqg 8331484 47076088".Split(' ').ToList());
        items.Add("ionsetxlme 50894030 90753681".Split(' ').ToList());
        items.Add("tcmyyprcrr 97370903 99391175".Split(' ').ToList());
        items.Add("lqmnepabqe 64018581 38771766".Split(' ').ToList());
        items.Add("ajpabzbhdc 32979273 96137720".Split(' ').ToList());
        items.Add("ekrqcwicoc 36674386 39669836".Split(' ').ToList());
        items.Add("njwmrxabzq 11779509 9712239".Split(' ').ToList());
        items.Add("jitanozhsm 81384542 60474567".Split(' ').ToList());
        items.Add("ckhnvowgis 36525918 78568830".Split(' ').ToList());
        items.Add("xsqufhybxb 44682811 12211674".Split(' ').ToList());
        items.Add("ridfljhtlo 52880814 90682063".Split(' ').ToList());
        items.Add("fjmazfxjin 88961181 21950755".Split(' ').ToList());
        items.Add("rinmvyuhij 11047094 3084326".Split(' ').ToList());
        items.Add("fzjssrwgia 94399754 38620125".Split(' ').ToList());
        items.Add("dmzksvbmev 61465285 12296921".Split(' ').ToList());
        items.Add("lnwotdqimg 41441741 32900914".Split(' ').ToList());
        items.Add("jzhadcfeje 25709965 51261153".Split(' ').ToList());
        items.Add("gnfwgkjmda 43350428 2083907".Split(' ').ToList());
        items.Add("fgzwwfzrjq 16779669 17218947".Split(' ').ToList());
        items.Add("qfsoxhekmg 85237300 33388372".Split(' ').ToList());
        items.Add("vmpfowrtfy 55843710 14880231".Split(' ').ToList());
        items.Add("kqijpdetjm 39050511 35915331".Split(' ').ToList());
        items.Add("mitjhqgxkw 85768295 55979194".Split(' ').ToList());
        items.Add("deaxcuwcuh 10219478 46032142".Split(' ').ToList());
        items.Add("rimfrvaevm 93846394 40140748".Split(' ').ToList());
        items.Add("zyasnrxdtx 97540138 16544572".Split(' ').ToList());
        items.Add("uujhekvplp 30939976 6601925".Split(' ').ToList());
        items.Add("gxxzjxvxjp 3128704 73221843".Split(' ').ToList());
        items.Add("eivtnjflph 50207904 1338367".Split(' ').ToList());
        items.Add("adgvvikjpg 88259802 15265073".Split(' ').ToList());
        items.Add("dvjtjmjvjg 4270846 89333261".Split(' ').ToList());
        items.Add("awqlbwlqnt 48241878 8305471".Split(' ').ToList());
        items.Add("sydvqxxunj 74519666 66924972".Split(' ').ToList());
        items.Add("ekmrwaibnw 9356902 11939371".Split(' ').ToList());
        items.Add("tyvprtmprd 11693533 96778988".Split(' ').ToList());
        items.Add("cyqfclukwi 8079961 94391922".Split(' ').ToList());
        items.Add("jkrpavsnrc 54291189 47344039".Split(' ').ToList());
        items.Add("mpuyydryaz 98831517 56447088".Split(' ').ToList());
        items.Add("kliaomnhtg 13126229 69198809".Split(' ').ToList());
        items.Add("wbywyizhpk 28524019 10823341".Split(' ').ToList());
        items.Add("bgvprxejcj 73215019 9673180".Split(' ').ToList());
        items.Add("ujuslcgird 26760338 38293965".Split(' ').ToList());
        items.Add("qiwxowrnup 89443243 18613935".Split(' ').ToList());
        items.Add("hmvpmohmlf 99549080 7811437".Split(' ').ToList());
        items.Add("jxvjeussez 25469610 48566182".Split(' ').ToList());
        items.Add("osqzlnyoyo 18008542 60328323".Split(' ').ToList());
        items.Add("ioupwjvrmg 77001705 4180262".Split(' ').ToList());
        items.Add("maswneoqbi 20583376 8330109".Split(' ').ToList());
        items.Add("klldxnuxyq 30246702 38272267".Split(' ').ToList());
        items.Add("hlmnynqbmo 60326648 99066974".Split(' ').ToList());
        items.Add("wlkijxsied 11936916 92349775".Split(' ').ToList());
        items.Add("bsqvheggly 7305710 48288137".Split(' ').ToList());
        items.Add("jjogyhsbag 67822876 66331398".Split(' ').ToList());
        items.Add("cwvprwtyre 53159714 71279514".Split(' ').ToList());
        items.Add("afegilxqbz 62836748 4432780".Split(' ').ToList());
        items.Add("cuhvuvcdud 32322088 5041348".Split(' ').ToList());
        items.Add("lykubdzbno 61135124 9242646".Split(' ').ToList());
        items.Add("lxokcxdhek 6589195 61407877".Split(' ').ToList());
        items.Add("tybcvmrziu 27704662 93955592".Split(' ').ToList());
        items.Add("fihxwlhuri 49821663 20024867".Split(' ').ToList());
        items.Add("stckzrchrg 49323038 24682947".Split(' ').ToList());
        items.Add("dcmrnyszgq 16219437 55611646".Split(' ').ToList());
        items.Add("wkwblbphjo 57130010 55377150".Split(' ').ToList());
        items.Add("xgmoldufqo 12003794 65373963".Split(' ').ToList());
        items.Add("mpcxuzktos 14424399 66597304".Split(' ').ToList());
        items.Add("lsqxgvtecl 73563691 3537433".Split(' ').ToList());
        items.Add("zkziisbkig 38129433 96139758".Split(' ').ToList());
        items.Add("wbraenkebm 85261042 15626478".Split(' ').ToList());
        items.Add("fcjfjhakhk 50850464 55029208".Split(' ').ToList());
        items.Add("morduycquw 98688134 24169319".Split(' ').ToList());
        items.Add("izfaiqyuko 94401055 55599899".Split(' ').ToList());
        items.Add("sqglwhxeqi 89820984 33252825".Split(' ').ToList());
        items.Add("dzmyffvnzr 30744293 65241391".Split(' ').ToList());
        items.Add("rxlmahpvtw 2051736 20277889".Split(' ').ToList());
        items.Add("engmnvdtpd 51843963 27402794".Split(' ').ToList());
        items.Add("wsblltveye 93048273 99115428".Split(' ').ToList());
        items.Add("ldqzhxetrb 92797627 76589267".Split(' ').ToList());
        items.Add("pvvtoiojle 16744373 12091520".Split(' ').ToList());
        items.Add("znbveuvmgv 85645633 41882607".Split(' ').ToList());
        items.Add("laxfqnjbxu 12141912 22445854".Split(' ').ToList());
        items.Add("dmmfavdmqe 61522923 64225099".Split(' ').ToList());
        items.Add("zvljolhenq 83916606 87505674".Split(' ').ToList());
        items.Add("tqdlpbblsk 47322174 84601294".Split(' ').ToList());
        items.Add("houpcjxunq 28658481 23242528".Split(' ').ToList());
        items.Add("ikwgmdorhl 66883475 73106233".Split(' ').ToList());
        items.Add("bryyonhqfk 82575996 18802319".Split(' ').ToList());
        items.Add("gybwlilqyq 54971344 90296531".Split(' ').ToList());
        items.Add("rxhfjijfre 51649649 81725222".Split(' ').ToList());
        items.Add("zxyuokxuoj 67787628 45217019".Split(' ').ToList());
        items.Add("bqclqzwalw 90453273 2411414".Split(' ').ToList());
        items.Add("hdqyqgixnf 41732730 32096454".Split(' ').ToList());
        items.Add("kmtdsiuaze 20597324 47640278".Split(' ').ToList());
        items.Add("rgemaxnwlx 47984848 8560087".Split(' ').ToList());
        items.Add("knljmcaxxx 9103906 46406049".Split(' ').ToList());
        items.Add("eutwrwlovq 58967527 2455554".Split(' ').ToList());
        items.Add("maumvxavlc 29407804 13283330".Split(' ').ToList());
        items.Add("falebyvpyn 15374291 2557330".Split(' ').ToList());
        items.Add("bwgqzclgui 33432883 1325159".Split(' ').ToList());
        items.Add("qlcwmisdib 49303628 93572944".Split(' ').ToList());
        items.Add("psyiomalxw 86330600 11818608".Split(' ').ToList());
        items.Add("sacxmapwvc 13575272 15797789".Split(' ').ToList());
        items.Add("pdgkytkcgz 61520808 41961271".Split(' ').ToList());
        items.Add("bqctwppfii 59263214 85496513".Split(' ').ToList());
        items.Add("hyvxksnvgk 2963600 5193764".Split(' ').ToList());
        items.Add("nozgoecjra 61833448 62447654".Split(' ').ToList());
        items.Add("yvqbrgrewd 62518420 40864534".Split(' ').ToList());
        items.Add("vvaptwimyz 83477600 9598553".Split(' ').ToList());
        items.Add("zvlpdwmnyi 34935679 10693588".Split(' ').ToList());
        items.Add("vvklnpmphr 41479409 98198944".Split(' ').ToList());
        items.Add("ytaaupawbg 88865769 62334207".Split(' ').ToList());
        items.Add("hicezixvfp 92391798 82853939".Split(' ').ToList());
        items.Add("ctkzjgpckc 90711686 63874388".Split(' ').ToList());
        items.Add("stutlsyrwn 9251124 71080039".Split(' ').ToList());
        items.Add("dlqevdfzve 6390258 28259278".Split(' ').ToList());
        items.Add("mdggjgigvn 77056834 25847232".Split(' ').ToList());
        items.Add("ituvzypxqu 59198222 64474726".Split(' ').ToList());
        items.Add("tlxjzkrocx 69823549 82898515".Split(' ').ToList());
        items.Add("bxonldduby 48822347 4390031".Split(' ').ToList());
        items.Add("sytpgpmjdy 53323365 98093334".Split(' ').ToList());
        items.Add("avalmlfjnm 52655425 14330122".Split(' ').ToList());
        items.Add("duvoabwkxm 71483452 92302068".Split(' ').ToList());
        items.Add("uvfadpvmqz 35842032 35198040".Split(' ').ToList());
        items.Add("bipfvmnuro 25849432 49174797".Split(' ').ToList());
        items.Add("fxxuoegnah 25753408 10108897".Split(' ').ToList());
        items.Add("bhpwxoisbx 31417412 57727877".Split(' ').ToList());
        items.Add("raxemodfrb 81276927 14691175".Split(' ').ToList());
        items.Add("mnftysylhh 38154069 6686299".Split(' ').ToList());
        items.Add("lnqewcpgcf 92112628 11001575".Split(' ').ToList());
        items.Add("qjsyalwgeq 86263326 60840091".Split(' ').ToList());
        items.Add("sfyekgszpc 3450322 71780720".Split(' ').ToList());
        items.Add("iodabkjync 96972658 65332089".Split(' ').ToList());
        items.Add("taydqzdzcc 38853860 66378066".Split(' ').ToList());
        items.Add("oaofyakfoy 65518123 76656529".Split(' ').ToList());
        items.Add("tfafmzvvxq 19674055 50736169".Split(' ').ToList());
        items.Add("dkzirbrjxl 62242152 65269731".Split(' ').ToList());
        items.Add("xlbuleqdhz 70211688 97487123".Split(' ').ToList());
        items.Add("jfygimpqcp 1237591 1540357".Split(' ').ToList());
        items.Add("yqugqqluox 35037184 57296921".Split(' ').ToList());
        items.Add("icinwgaddo 52793028 71143252".Split(' ').ToList());
        items.Add("oibtfghuek 78330333 46311611".Split(' ').ToList());
        items.Add("yebalfiwdk 21735002 27958624".Split(' ').ToList());
        items.Add("cfvqeshepe 2090125 87161633".Split(' ').ToList());
        items.Add("qmavwzsuiy 58446081 23561087".Split(' ').ToList());
        items.Add("cddcgthehl 5608629 56018158".Split(' ').ToList());
        items.Add("ffouuxmzfh 48825365 45341291".Split(' ').ToList());
        items.Add("ipihyvskbh 75843651 56211952".Split(' ').ToList());
        items.Add("gknqwbvpkp 63506452 38147939".Split(' ').ToList());
        items.Add("daqlpefewe 48002683 11823643".Split(' ').ToList());
        items.Add("zjbawbphuo 34788862 99020760".Split(' ').ToList());
        items.Add("dbsogthcwg 96631113 86365192".Split(' ').ToList());
        items.Add("yocbwcqrwa 13073932 20319795".Split(' ').ToList());
        items.Add("lmieibdqqh 11672818 61904960".Split(' ').ToList());
        items.Add("hfcciycngd 73071236 40595946".Split(' ').ToList());
        items.Add("objbaisxto 2291044 55756995".Split(' ').ToList());
        items.Add("fyllqeqqbm 95697619 29517063".Split(' ').ToList());
        items.Add("kmjkvosaun 69563606 13889941".Split(' ').ToList());
        items.Add("xewqmhkwit 58183639 25834797".Split(' ').ToList());
        items.Add("yuftiprfah 58790569 28175875".Split(' ').ToList());
        items.Add("exeovdhxfl 39771333 50450537".Split(' ').ToList());
        items.Add("bejcwucpgr 6062976 74967778".Split(' ').ToList());
        items.Add("xphlzqnmaa 31346310 88520389".Split(' ').ToList());
        items.Add("lazvawddcv 40629341 25322487".Split(' ').ToList());
        items.Add("rjdlkvroic 33060511 37836249".Split(' ').ToList());
        items.Add("zduypanmgo 5994400 4241836".Split(' ').ToList());
        items.Add("dqutwrctay 63476639 18151871".Split(' ').ToList());
        items.Add("trvafeaikq 8374371 54594920".Split(' ').ToList());
        items.Add("recbpzrwge 11734636 48510306".Split(' ').ToList());
        items.Add("glwpelnlqg 71898442 99397525".Split(' ').ToList());
        items.Add("zxgvfnaeob 75532136 70051710".Split(' ').ToList());
        items.Add("ilrbqaomef 36591643 32214547".Split(' ').ToList());
        items.Add("xgpjivfmnj 94301808 56719038".Split(' ').ToList());
        items.Add("mjfugpftgt 2552839 74061243".Split(' ').ToList());
        items.Add("htikrqkyvc 46322264 66004522".Split(' ').ToList());
        items.Add("zyxrnwmewe 88904405 28483147".Split(' ').ToList());
        items.Add("guafxncgax 76562261 48988340".Split(' ').ToList());
        items.Add("gwskmumvlu 32145176 53974479".Split(' ').ToList());
        items.Add("hqodzysych 82453666 88605835".Split(' ').ToList());
        items.Add("fczklkuwtm 40370161 60740810".Split(' ').ToList());
        items.Add("pggnnumbdx 33431550 20905648".Split(' ').ToList());
        items.Add("dolwdaknvw 95294028 49580691".Split(' ').ToList());
        items.Add("pqprutdfjy 99538525 30413552".Split(' ').ToList());
        items.Add("txqbiippdk 80990889 93820959".Split(' ').ToList());
        items.Add("blagvmegee 91929947 34273880".Split(' ').ToList());
        items.Add("nyfhclsvci 76938598 30257936".Split(' ').ToList());
        items.Add("jabjmdqufd 40748557 81502152".Split(' ').ToList());
        items.Add("yjorvnrxvu 26949617 21028113".Split(' ').ToList());
        items.Add("eicaxrelhb 28087131 61492024".Split(' ').ToList());
        items.Add("ggmnjqoqkz 72781610 44003948".Split(' ').ToList());
        items.Add("jgxtmpqkgr 34594290 47631560".Split(' ').ToList());
        items.Add("muxuvdwzbg 20415344 12770955".Split(' ').ToList());
        items.Add("dtueqccuot 36359326 5836334".Split(' ').ToList());
        items.Add("vgdvswpxzb 33267827 62805059".Split(' ').ToList());
        items.Add("kxwbwasuqb 91229361 66".Split(' ').ToList());

        int sortParameter = 1;

        int sortOrder = 0;

        int itemsPerPage = 17;

        int pageNumber = 1;

        List<string> result = Result.fetchItemsToDisplay(items, sortParameter, sortOrder, itemsPerPage, pageNumber);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
