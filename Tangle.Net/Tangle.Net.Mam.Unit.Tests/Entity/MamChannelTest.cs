﻿namespace Tangle.Net.Mam.Unit.Tests.Mam
{
  using Microsoft.VisualStudio.TestTools.UnitTesting;

  using Tangle.Net.Cryptography;
  using Tangle.Net.Cryptography.Curl;
  using Tangle.Net.Cryptography.Signing;
  using Tangle.Net.Entity;
  using Tangle.Net.Mam.Merkle;
  using Tangle.Net.Mam.Services;
  using Tangle.Net.ProofOfWork.HammingNonce;
  using Tangle.Net.Utils;

  using Mode = Tangle.Net.Mam.Entity.Mode;

  /// <summary>
  /// The mam channel test.
  /// </summary>
  [TestClass]
  public class MamChannelTest
  {
    /// <summary>
    /// The test public channel creation.
    /// </summary>
    [TestMethod]
    public void TestPublicChannelCreation()
    {
      var seed = new Seed("JETCPWLCYRM9XYQMMZIFZLDBZZEWRMRVGWGGNCUH9LFNEHKEMLXAVEOFFVOATCNKVKELNQFAGOVUNWEJI");

      var channelFactory = new MamChannelFactory(CurlMamFactory.Default, CurlMerkleTreeFactory.Default, new InMemoryIotaRepository());
      var channel = channelFactory.Create(Mode.Public, seed);

      Assert.AreEqual(seed.Value, channel.Seed.Value);
      Assert.AreEqual(Mode.Public, channel.Mode);
      Assert.AreEqual(SecurityLevel.Medium, channel.SecurityLevel);
    }

    /// <summary>
    /// The test restricted channel creation.
    /// </summary>
    [TestMethod]
    public void TestRestrictedChannelCreation()
    {
      var seed = new Seed("JETCPWLCYRM9XYQMMZIFZLDBZZEWRMRVGWGGNCUH9LFNEHKEMLXAVEOFFVOATCNKVKELNQFAGOVUNWEJI");

      var channelFactory = new MamChannelFactory(CurlMamFactory.Default, CurlMerkleTreeFactory.Default, new InMemoryIotaRepository());
      var channelKey = new TryteString("NXRZEZIKWGKIYDPVBRKWLYTWLUVSDLDCHVVSVIWDCIUZRAKPJUIABQDZBV9EGTJWUFTIGAUT9STIENCBC");
      var channel = channelFactory.Create(Mode.Restricted, seed, SecurityLevel.Medium, channelKey);

      Assert.AreEqual(seed.Value, channel.Seed.Value);
      Assert.AreEqual(Mode.Restricted, channel.Mode);
      Assert.AreEqual(SecurityLevel.Medium, channel.SecurityLevel);
      Assert.AreEqual(channelKey.Value, channel.Key.Value);
      Assert.AreEqual(Hash.Empty.Value, channel.NextRoot.Value);
      Assert.AreEqual(0, channel.Index);
      Assert.AreEqual(0, channel.Start);
      Assert.AreEqual(1, channel.Count);
      Assert.AreEqual(1, channel.NextCount);
    }

    /// <summary>
    /// The test restricted message creation.
    /// </summary>
    [TestMethod]
    public void TestRestrictedMessageCreation64Bit()
    {
      var expectedPayload = new Bundle();
      expectedPayload.AddTransfer(new Transfer
                           {
                             Address = new Address(),
                             Message = new TryteString("AQRAQLYEXHTXQUVYAXBDJZFWM9QPHXNQRVVGEODVNZAQMPXIHVYDFLHKDBFLSEUDGHVGNYFLEBQTJORJ9BDWXYUBYQDBKYHXGCIRVRJLLRQCBFSYYFTRVRPYJTHIIOOFDISBILGHQCEWSNLRXRKPTBSBO9ENPHHCSTPGFEMQEWXEZ9BZIX9ICPGKLXKRGBFGUVVAUEJLXIXMDUOTZREGMSDVULQDHGQSLIHOAXHHXOZZDJUKDA9PBIXS9VAQVWVBYYMOGTCRXWSGIPAWRVVMDFLC9ZWARUVVGAHOTV9CBKAWZOLABYTYWRHPGYRIEOVCASDPBNXPVEQ9EASXF9IACICBBDBGGBQ9TXMMRGU9FFFWJEREBQTVXRRYTXG9HTKVNQPCJGEWIPKKPUETECNQFVDJOXNAHVGQKRWJLTQMHGZRWMCIIXVEPQGKYUINQB9ZVBORKPIVV9NXLFZVSBPDDYRCISBASVZJBBNXYARAOANTKCQNEZBAATBWSVBVVISHCYBBLJLYQUCRZVKASMHWTEFRKSQNUZ9YOFNWMZUJ9ZWGZYLVDBIOIUQKHLPEQHIF9FISNHLR9TDCBPQNUHM9RTGMVARZKKHISYKXTV9BSHDJNGUJY9OLMSKBFWPCOXJHAFAMRBIN9UXRKRLNODKIDLXRWFMQF9OWRYADJLEUQTAYYOLHQFFOWIYNMAG9NI9MKDMTDCKUGKJDPLWDWDRWWGCHYTKMTBPWYVBYYJXEHHLDZXOCGWSAFCAJDDIG9CLVRYGBQTBWXDFUJIXHODHT9INSECIDTNFXFLIZTFCYKAMMJGQPHNHYNBESVPSHXNYAVICPWEWGMT9RC9DXXALHMBPVKRPOXHOZVPKXPOKTPZLBWSUNXOHIKTICJDZVGLREREL9TDGAOMHRBZTZXKTIUFRPVY9SGQZZKPAHPZJEQJ9VF9EVOJHIXEPANATJVJVONHQK9XF9PDZSILBRXIYWVBGBMROQGI9AOCW9RVFXCOQCKJBMUWPOYAXDRC9G9XWRVJTMO9ZHDJTYKRQUJGMOTSUTVXOPYZK9KOZZNWNCNSWOSF9DLHPLSALNLZIU9KLXABKIQXNHHEOLRJN9HVTEXWPH9C9OTOCETMHJVQKHBFQEFJRBSYIZEUTRXHQJJYMCCURTSWAMDEASTTFVRYCDYDDUVKVHUVZPYSNEOXVXUEGENTIDFITOYTZEHLAARKPZBDXMUAWGOLRERABFSNFUHWIHQSBNKCFPCVRRIFOCYYSRVGEXYT9DKLWDMICVPQLZGFELCGKQLLBNRIXGUQBSLAKKWJUQKZNTPPQPHNSDHEYMWPIOSWTYWPSCAAQAYYIQ9LXXEBN9FSYFJTLHGZTDOSXFXAQLUNVS9IAJZOMXFRLWRLACPHXCUGARGBACABDUUXFHPURNAKQDDYUCQMQLGOEYDUEULPFVP9WBWFZYSXQOSHZQTEGBMTXBNFDOSMSNUQ9MHCPMINTTBWZKHUTSTDAXMJJNJZABAHLZVVLNIOAZQLUA9NQGGFBKO9GECCVFFLCUCOBIRMBXWWRWMPOVHNDFN9LG9BQJMWLVYFPCMO9HQTU9ZVXGKVVHQHDWYLAIRVUBCSFBGOGLP9DMNYKHLBSF9ZRICQSN9EBDCPUVYWSKZBNJYZECKC9GCRTZAL9NPWOFJUADDBGSKJIIDTLDJLQSGQDGA9QZGLABGXYVHLYVFATWOQHAVS9UWAMEU9VZTNFMDUZPMYRYPECPY9NTSS9QMSAJCLWCXOQZCHQFJOMW9FHUWKEPTZV9KCTWZTBGOWFFHOBSEIIQZ9FXEFPPVQRZLASCEAVVJWCZNUQMJEZCFO9UVOLPAPNJPOEEXYBAGGGUXOB9QUTCVAGDSYIKLDOAFNXSLHJST9QLOITR9RDWIBYNZVH9P9GGH9EJGUUAITTNCJCAPRLSFLUVEHVGNEF9QILNTUMYAFCZMMNLDTHKPJZAYUXNLIRSRIPELTXVBDNKTAEIETHHAMWLDORDRGQTRTBXKRYESYOWCID9NPUKCHXYORUIDMPUDVUWZVLYSIIAPTTTHYRWLGJIYHMKAU9PXGMXT9PFEWXXNXEXYRGUPVQ9ZVREQHHQMFJWJSFLVORIVDAVDRENFMZHYHDJSYCOLWB9RTAFXVKBWMSRGVLMHVHQJDNHPIVRDUSRKSYBZWBULB9QPFDEXQNLX9INXGLDQIJCAVSLNNRJSHOLQASBZTQF9QXV9QLHIPXLACEEEDEXTBJF9HNRWDLNQUIONKWXFST9NNXOAPNYHFOJWFTLFJEPTABUVUMVSGFQFANEKMVTGGFINNJSSWDXNJEVYBAPRLQQKOOJBDWSEMSUHXRCFBJTFFAKIYAMGAXCGAXWPFPUGCTWOPOMWJFGPKKYRYLWLVENOWPPNUQZEBLXEYAFQXTANUDHXYPZMXMMICYEZ9VONFTMYHMBWCJWW9HFSKZMPLOIHMTAXZGBNPEMDHYZHYLGYCJFYBYFGZILZPQ9UETUKNVPLISIALLJSRJNOAKFTL9DYDWNFBYSOBOCTCAVJGXTTLGLQ9SCMCHSFTDJXSKGHHZAEGGJUMYGB9IIELEGDSBLZKMTJJSYJWZCJWEKNGDX9PAQAOPHWRUIOTELQGTFEOQBZOYWMJHAQZMCEPQRKZGPVDVKPD9HMJWVJVQRJK9JKKB9OP9IQBRSAIFVGAIWQJYPXMYGIXAYXQTLDW9OTRPKRJAPFPPNPWQKSPUZORGCLJA9YJZJ9GTGP99DCSSGN9WT9WQAVTJBAZZASKTSFZSDLKXEJDSXTMGQMLWWZSDDWSPBZEZOERBQZFDYFKFQLWOOXDSKTVJALTYRMFAHVZFGVNHR9JQUNXYCC9ZBHGBVQLEQQFYXIFMGZRHKZM9XYFNU9JFHOZPHZPITFOLQZOVEJWQVP9JBIVQJKGUVSGADFYGSIZNAWWGZMDDGNS9FVROUFLLLOFFSRQIFMIHWOSCSDGDVA9XKBYMHIPPHHTNJBSZJYHNVWMBOUW9RYNNSJERIRCEAZGFREYUMZXGYCCWVGPUWQLZUVVZEUJG9KBYILXFRZRTCIUJMOMEEZHCNOYRVYQVCMGMWOHRDERKZETUNHZNEQWNUJNLBNXDVPYHNIZWOTXU9ASXOOSXUDYGG9BOORBKMTXBRRLKKOZSU9JTNXAFIU9IRRXEMQYQVFJISEXPTTCUBM9NJBDXARCHEWDQTGUVIGVKEHHHAZWVIVKPUWUGFW9KHXDGIKLOCLEATBNHYOCZXEFQKQUOVRNVHMGXJIBLNFETCYPZMRBBMLMKWBOWWLYXVEUYSNKSWTLPBDVWJDLKCUJVTORYLGRZZXDBQHBFLOAXVVRCSNCDGPDLQMNMWWJSXEHSVINRKCBBENJHJRIMXVGMQJDUROBI9YMIQDTLSUHETANLIALPSDTTAJWQKNLWKUOCUEKYRCUODUMABILWL9YP9KZEONKRHBLJFAVEVWTZDFICLLFMUFZVPWKYLCLFQKS9JFOCJC9LRJESEPMWYHDC9ELBQLPDKVEFMGEL9TBDAAYUMGRZ9YCGXALWJZX9MNHBSRJYNP9IARGKIZCCYKLNSMUB9AZWHSINIMPFCTSMMPKVHYHRRENSZZXVBIKMVPMTKSOBPQ9PMALTOV9GDPKTWAE9KTDYOA9NNANSQQOJECKEQ9ZBRDISIUZCAWSJGYCOPEIGMJBVBVQGWTGPAHADULEPFM9ALNCIXWVSCBVQRHQANTLDVEXMAOXFQDDUQYNZOHHFBIAEENWZWJXVQICBNZTCQUNW9AQRGAQXINGXBXOYVE9JNXYGUHSUFLPADVPJUFMECKHQSIRRDNBYSOOZK9GKCK9HTDLANJUAJZQVLNVGZRLXBIYLGUVGCZDY9OCBIOPPTBZMGV9OUCKGREHCVXDCZBSU9IXKONSZFKDQBWUFDEEZVBPMFKOTPFLBGPMSMZVGBRHOQHNMGUN9I9GQEBAPXBFLPNBBSP9MCVEDSOCVIDEZCNQUEHZVJTDMEOVFUFYRGCPBOOVQGUYQYCBMRJBTLVXRSVIKJQRPOPNOOGUFGHGYW9QDLPVRYRDTEDICCLR9WEZXFLVUNMAEMFLHHNHDSXVHPLBLGOQTVKDAHUCMDTFYTJATAEZRYEDIBJPOFTFCIAEUL9XAUUIBQCRBDTMEPWVGTSBODMHBYRWLBJIRVIDDXAKDHSQFIXYBHMHNLQLNYPDQFCMETQZNJCJZZYAJCBDUYXMXBPVQJZCXNGFXOSLDHJSZY9CHNXVDEJHRCIAPJRZUQ9FJHJBPYFDDGMJRQMNZY9YTAEOHRFOFKNTPWSPWPIAGWZZBM9OVRYQ9PDMSFFNWVX9ONILLWBDFXKGOBMHLWNDCXXUGFDJRMNRRHBNPKIVP9NKNBEKLIOFCNGVBTWVQ9GMPEUATEAGWMITUAZCMOGFFVTDWCFTVONROHASJHYFSXMDYDOCVRXZBUMKDZICCQFYBVDPYSABNKTUPADTWJZGKLBQWUPSEOJIITYTNYXMGBQSSUPYMTSCYLSLIZCVJTJPHBETOROBNA99"),
                             Tag = new Tag("ASDF"),
                             Timestamp = Timestamp.UnixSecondsTimestamp
                           });

      expectedPayload.Finalize();
      expectedPayload.Sign();

      var seed = new Seed("JETCPWLCYRM9XYQMMZIFZLDBZZEWRMRVGWGGNCUH9LFNEHKEMLXAVEOFFVOATCNKVKELNQFAGOVUNWEJI");

      var mamFactory = new CurlMamFactory(
        new Curl(CurlMode.CurlP27),
        new CurlMask(),
        new IssSigningHelper(new Curl(CurlMode.CurlP27), new Curl(CurlMode.CurlP27), new Curl(CurlMode.CurlP27)),
        new HammingNonceDiver(CurlMode.CurlP27, ProofOfWork.HammingNonce.Mode._64bit));
      var channelFactory = new MamChannelFactory(mamFactory, CurlMerkleTreeFactory.Default, new InMemoryIotaRepository());
      var channelKey = new TryteString("NXRZEZIKWGKIYDPVBRKWLYTWLUVSDLDCHVVSVIWDCIUZRAKPJUIABQDZBV9EGTJWUFTIGAUT9STIENCBC");
      var channel = channelFactory.Create(Mode.Restricted, seed, SecurityLevel.Medium, channelKey);

      var message = channel.CreateMessage(new TryteString("IREALLYWANTTHISTOWORKINCSHARPASWELLPLEASEMAKEITHAPPEN"));

      Assert.AreEqual("RRPXQHDJY9BKXC9NGHDCSHRIDYORSUUEPFHXPQVDGSQTVYPCGVIZRWQINOUYFDUXTHFTKHLBOLYLHMKE9", message.Root.Value);
      Assert.AreEqual("BAVSMNXFTVBBEPXVROQYWBFHAELANDS9UFLDEOERJGKMXOGTL9UBEJF9WUDNGKUEDFZYAAFACRRRACDHV", message.Address.Value);
      Assert.AreEqual("OLHRFQPHPPQWTVSZNIZEKFOB9JPWKWQQPUCNLFAVEYCL9QVXRWFTDT9KPIHERRULOOBUKTJZJWKENTPLO", message.NextRoot.Value);

      Assert.AreEqual("OLHRFQPHPPQWTVSZNIZEKFOB9JPWKWQQPUCNLFAVEYCL9QVXRWFTDT9KPIHERRULOOBUKTJZJWKENTPLO", channel.NextRoot.Value);

      for (var i = 0; i < expectedPayload.Transactions.Count; i++)
      {
        Assert.AreEqual(expectedPayload.Transactions[i].Fragment.Value, message.Payload.Transactions[i].Fragment.Value);
      }
    }

    /// <summary>
    /// The test restricted message creation.
    /// </summary>
    [TestMethod]
    public void TestRestrictedMessageCreation32Bit()
    {
      var expectedPayload = new Bundle();
      expectedPayload.AddTransfer(new Transfer
      {
        Address = new Address(),
        Message = new TryteString("AQRAQLYEXHTXQUVYAXBDJZFWM9QPHXNQRVVGEODVNZAQMPXIHVYDFLHKDBFLSEUDGHVGNYFLEBQTJORJ9BDWXYUBYQDBKYHXGCIRVRJLLRQCBFSYYFTRVRPYJTHIIOOFDISBILGHQCWXSNLRXRKPTBSBO9ENPHHCSTPGFEVK9GVOWCBTJKVRANFBPHEOQNTJJQNYWQSYYRXZMFHADWUQJVBOLP9BUV9PXUIAKDUGRICOLQXXSXNGNMUMBWJRJDBSUJWSPGLXMHBLUUSSWSQUTSWKRRPWURYJYHRHSRCLBEBMHKVFJMLYDDEIHHBCAZYLLNGMFTUSUZA9VAWSSFSKLDIFYDDZJXJZ9VRIADVEAPMRBBUAOJCWCWMBUEVGBFMXPHQEE9JNPLLSDBDJSLXZXISGDOAMGQSVMOMKOWTWJPYCDKXRRBBKLPJRJMN9LJZQZADQQYXNBNFQDBITXBXPSMWDNNJAODPSEJRQZCKTLSOLUIMOWXZHYXJOXAGRJC9NNGWLYY9VQYW9IYFCQWDZQJDNWHVIXEIYSHTSOGRHMPQZ9YUTWDCRUEZGJTKVDRFNZVRBVAJBBNHILDFSBPNJKBUVXW9CDOEGVFPAWUZROYEBYT9NHI9DNGLHWPSKMJELJSMVTRNGEJNAMNEWUQ9GSRANMRIEB9GWXJD9GX9EHTRNYEYZJFKALYJVPUITHKGMM9QJDOKHWXQ9YN9ZBBCRNESWWBPWZIQVGWDQSRVROIRTPK9STFWRDDUFDKSLQQOXRWSSQCOHIJUJLPOBUVNWLOGGXDMEFOQHXSGQOZVQGYLUABLBJHXZRRIB9ZTLAXHHSRHAODYTSDTJUGRWVDJAJNRNDL9YVEPKLVAQFPAONMKOHHCLAZWFTAZTMEQKGNMNBYHBGNNOV99HCMQDRZEGGPAWA9FFO9SESTP9TSFXLCYPJJ9JKROY99VVHENCHSSSXKDAFRGOKAKIWCOHXYNFPKKWCBSGENRBX9FQFBITIO9999USHGAMQMBYPYPQANDGZXIPYVFZCTRGALNR9XGZBYAKQYIJDSBTWHIJQMOVOVBVCRUXZD9IGMODZPXLGTKYOWRVQC9YYVVBVMDRSUUPJDJUMLNCPGZJLTGQPQOXKGKUWASQQ9AER9JLWMQA9GLPATMVRDFIWLC9GBIKRXGJSZLPZVKGTWIIDCGXIDKMLQTCWTPICN9UZZXEOFFCQSJPOXFSCEHJNGIGOYIFZFMPWHJOFZGIYRFWOZCSSHKPWHDEELMN9ZWULHRMRHVNGTNUEZEMRINSVYEGBOJMNYFWNLFSIHHRIFXZRLEGFIEOT9WYZQXFTKXRAYRRKDV9VYUBSZAKARAIZYDWBEDLLOCAXQZIXSIRFGCGZWVRRCME9TXPTDUYLYUGLIBENQ99SDQLYFBJZHGQYQBLJMLFZLQLPHYMCFMTOSDA99DXAMCEAMBGNFFDJIKTUCBHSYKH9KLRVBYXOJJYKZYXJLIKIZFQHNFWWNCQACXZIXDLJXNU9UNZQJMFLJJXGSEPXIFRDKSUENGGELMFPVQKHAYPHMIPHVKZTNFTWMERRTVFHJLKILHRX9XSVYJZQKQXIMIMPDGCNXZKXUBNZOVXMCZXGXZTVBTIQUZ9GDQJGIHFKFXYZHDNGPIUXLIKSDBQQNMJCVRJUKQVJWGOFOBTXDSFLM9BGYZJREIBUBEVCOME9NNKHFEKWGJRTMZFDHFZY9YHTFJNCNZBGMVEEKUYPZBYQQFVVZEFSQDXOWTNUSU9GUTS9ITJAYYELPZYITWELVOAKMPTUIL9UJD9TN9HVLIYWAHMQBIHLUSBRSAGXQRAOOKGIBYMM9AOLC9DQVMNFMPGDSQUTWMRKVKE9FRZNCQJDVDKBINILRFKBEEDZTWI9UUCNLIMT9MLQRMBRJQLKHJXEKWJDEK9WAKXUJVWMUNLBUSVYSUZDOIEJAKZZOWPQFNKDLPDICGTQKOSBPWKHGPBUWYXWYVPIOIELDLIBPI9FJRSHVEKRNMQ9VPOCCCASWKL99TZCFNHLHVMOOFNBGSRXYKCKJOLNEBYAFCRMDHOVWUZ9MIFDSRRFSHSIWIN9WLLXMOKCXYTTESFZUNMQAHYVOVQQH9YZVOQATUPEPGCCGTPBAAOSPJ9ALPYXONR9OCODZDJPNPMQIREEXICFQIWRZ99OPS9ALP9GLPTTWGRJHATSJJTEKFZDJYEUKBIAACLOALTSXWCCL9GBUTWIXVEW9HYLVKRRRAATNYMGSAKLUN9HJQPIMXJOYIDXNONMHXZUGXOFIQIFBTPYDXXMKOAUUNOJU9IIXFLSSWKOCRJKXNWKKAMJRMFYSMAOWSCI9NTRQKT99CIDHJMZWSDKAIKOYWHSCJZRQWWDZOC9TKXHXCDN9GTMMGXXHXIJFMTCQFTDAKPEPQLNVCIE9UMIYXHDQUGPJSHPMRFCHMPGOYHVATXBIGOCZAFDNTVMJRJIVQDLNQYNSASMLXPSFUMYBGHXTCFYDLOGOCDTWPZMVPKMP9EEXEKNMSTEQKFZIVU9DKHSEQA9XQNOKUK9ABSTZ9XRPDMDECMYRRGSYHEZDAWEDGTQSMRC9DQ9FUWS9QELTDYZCRFYABZKVLCFGVKYGYIWJGNQKI9ONMXWFJNFIEPZRSSLNUUQOXK9YXQYMWR9B9UAUXYYONKYUG9JAJOUMLKQOXBD9JBLAQHXBJINNLBXKYGYLPRLASOFISEFXG9KENN9YFFP9J9NVVYKAEFAUTIQRDTVKVHQYEWJOGQEUPSWEIMYWYYEZRGJUEDAHDYPQEGX9KTUODLORTCJZGJCKFGEJTWRGEACRRINEQBUWS9NUPP9BMONGQQABVGBLRQXZJYXDHS9DFWAWLOZVKSDZD9UGBPKDCHLYEAUOABXKMNWTSUZTHTZBYOALUHQHSEK9WPGWGVNQEGVDDFZJXLAYINRUQYQBROPB9RGAFWMPOBOANCGW9DJJ9NUIHLQE9RNZOHLPYAIACONJXYFRBAOVJEWOTO9HZCZOVJGHQOGGJAB9QUWDRI9KLX9EGOHGTJIYQHTTMAAETKGBLDQXGRTJOEHRIAPXACPFTVGIXUJFZXUCX9EHUESMGQN9EHXEQTSKJHWDIR9OJYP9USDPWECONYRTFZREIZHOBAOXK9FCEOWCLUNKEWKE9JPQGDZ9PWAVQUMNBLVMESODMGJAIVNVJSFTQFL9RTTCJAFIMIGXASIREOXLNVEHMHPQZIKIPRQWFGYLQHVPMBNIWTWINSKW9WIWVDKHAIHNMBOCETYLNTJMA9XMEVQBPUFPKXJHXHPQCFKF9UYQQFKBBPPZMNAKPMMHPLBPDAOACLZ9HKVFGGMQHHHQLWYWYYGNXPEITKTVNURENFBAOBXITZDYCUSASIYEVJBYDLBIMUF9HILXKYH9IDYOFEQMBHJJBFDTNPDXSNSXCPUFGRIOXNYOSKHBILRWEFWZELL9GLNQOMPLMAPTOIJXSQXNPIW9XLMYEYVTNM9BVLVAIPZSYTCHHXGBQXHCBOQAUHZXKDWUREOOGKK9S9ZTKHGIQWHZOOFCGXBBCSYPGOGNRJLGVNWAGJZWKKLTHCJG9FJVRXMHQARRAHGUTITDDIMTIZAYARKJMQFCEAAOTHSHXDQKSNGMN99YGWRNLNMJXXFIQD9THOIHINYIEJMWRCZTAHJC9QIAKDIHIELNIMDKHFFWVCAHGMITJYNZ9XZSLFCGFFEQLONULNTQAJLOJTWO9BJQEBGTY9OCJBXKXNDEJWCDRYCNFDKYODHPAHQBGDXHMLVETVNRLRIJDHKAHZBAOFGMQFSTHPHBXKRAJFVIUDCKGNCDD9XTFDVNW9RLRNN9QRRUGOTMRRSVISCWE9ALTXCOCYHIQGXLGDB9RGICVSTUHJFWMWQCUICLJZCACGYCUHMGTGEJGAACGEXKJNJWKUGXRNBTEKIYUNXZZHXASCBPRDJAVXWESHU9DW9UVPJLWBKUXPDAIQ9JQPAHPMGVRUY9RLAMRTOKDVVUAZAPMNBSHRNNYDGC9BKAKKBPGHFDOHXCFWNSH9FZUMQHXMIUYKQLKHAYXPNEDYDUXTZXUKTBRJGBSZFMCNRZIQQLOLPRZPZBCX9EZBRUFGHGHBLYBLYYWZACGWGYRGV9IGZLTXOIMSCOTBNIGUXMOPVOFKIEUZASTZAHKXLYECJFLVZCORRFYDNVCYSKFCREQXXMDEHPSQFDERBICWFMOJS9PPSQYTVEXYSYGHWIWITZHRBZLHJWUYWQCAPLSBYJTJGCUXQPITAUJX9WEUVJDNUNKSDLHWDWKDQARSRKSLGLUCDNCERMKOJXCRXWCCYIAQZVGJLYTYQNGUDYYMXXL9XDBLEWPRMAY9DMMUHYUPMNBRRXJDIFDWEFJBRPYMPDPIPGXGXBMZ9JHAOISUMCNGUNCCPWKFJNBR9ZATRMDTOFDKMBQEZSCDSBNNEIUUCDHPHFBOBXLNGPOVZCATQRKVYSQHSHIVFZTW9BHPTPXUJGNNUBHWLZF9TBA9JONTWZRWHGHFIQGHAKSWBAHB99"),
        Tag = new Tag("ASDF"),
        Timestamp = Timestamp.UnixSecondsTimestamp
      });

      expectedPayload.Finalize();
      expectedPayload.Sign();

      var seed = new Seed("JETCPWLCYRM9XYQMMZIFZLDBZZEWRMRVGWGGNCUH9LFNEHKEMLXAVEOFFVOATCNKVKELNQFAGOVUNWEJI");

      var channelFactory = new MamChannelFactory(CurlMamFactory.Default, CurlMerkleTreeFactory.Default, new InMemoryIotaRepository());
      var channelKey = new TryteString("NXRZEZIKWGKIYDPVBRKWLYTWLUVSDLDCHVVSVIWDCIUZRAKPJUIABQDZBV9EGTJWUFTIGAUT9STIENCBC");
      var channel = channelFactory.Create(Mode.Restricted, seed, SecurityLevel.Medium, channelKey);

      var message = channel.CreateMessage(new TryteString("IREALLYWANTTHISTOWORKINCSHARPASWELLPLEASEMAKEITHAPPEN"));

      Assert.AreEqual("RRPXQHDJY9BKXC9NGHDCSHRIDYORSUUEPFHXPQVDGSQTVYPCGVIZRWQINOUYFDUXTHFTKHLBOLYLHMKE9", message.Root.Value);
      Assert.AreEqual("BAVSMNXFTVBBEPXVROQYWBFHAELANDS9UFLDEOERJGKMXOGTL9UBEJF9WUDNGKUEDFZYAAFACRRRACDHV", message.Address.Value);
      Assert.AreEqual("OLHRFQPHPPQWTVSZNIZEKFOB9JPWKWQQPUCNLFAVEYCL9QVXRWFTDT9KPIHERRULOOBUKTJZJWKENTPLO", message.NextRoot.Value);

      Assert.AreEqual("OLHRFQPHPPQWTVSZNIZEKFOB9JPWKWQQPUCNLFAVEYCL9QVXRWFTDT9KPIHERRULOOBUKTJZJWKENTPLO", channel.NextRoot.Value);

      for (var i = 0; i < expectedPayload.Transactions.Count; i++)
      {
        Assert.AreEqual(expectedPayload.Transactions[i].Fragment.Value, message.Payload.Transactions[i].Fragment.Value);
      }
    }

    /// <summary>
    /// The test public message creation.
    /// </summary>
    [TestMethod]
    public void TestPublicMessageCreation()
    {
      var seed = new Seed("JETCPWLCYRM9XYQMMZIFZLDBZZEWRMRVGWGGNCUH9LFNEHKEMLXAVEOFFVOATCNKVKELNQFAGOVUNWEJI");
      var curlMask = new CurlMask();

      var channelFactory = new MamChannelFactory(CurlMamFactory.Default, CurlMerkleTreeFactory.Default, new InMemoryIotaRepository());
      var channel = channelFactory.Create(Mode.Private, seed);

      var message = channel.CreateMessage(new TryteString("IREALLYWANTTHISTOWORKINCSHARPASWELLPLEASEMAKEITHAPPEN"));
      var expectedAddress = curlMask.Hash(message.Root);

      Assert.AreEqual("RRPXQHDJY9BKXC9NGHDCSHRIDYORSUUEPFHXPQVDGSQTVYPCGVIZRWQINOUYFDUXTHFTKHLBOLYLHMKE9", message.Root.Value);
      Assert.AreEqual(expectedAddress.Value, message.Address.Value);
      Assert.AreEqual("OLHRFQPHPPQWTVSZNIZEKFOB9JPWKWQQPUCNLFAVEYCL9QVXRWFTDT9KPIHERRULOOBUKTJZJWKENTPLO", message.NextRoot.Value);

      Assert.AreEqual("OLHRFQPHPPQWTVSZNIZEKFOB9JPWKWQQPUCNLFAVEYCL9QVXRWFTDT9KPIHERRULOOBUKTJZJWKENTPLO", channel.NextRoot.Value);
    }
  }
}