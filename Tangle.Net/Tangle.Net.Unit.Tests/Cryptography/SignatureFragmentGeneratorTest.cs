﻿namespace Tangle.Net.Unit.Tests.Cryptography
{
  using Microsoft.VisualStudio.TestTools.UnitTesting;

  using Tangle.Net.Cryptography;
  using Tangle.Net.Cryptography.Curl;
  using Tangle.Net.Cryptography.Signing;
  using Tangle.Net.Entity;

  /// <summary>
  /// The signature fragment generator test.
  /// </summary>
  [TestClass]
  public class SignatureFragmentGeneratorTest
  {
    #region Public Methods and Operators

    /// <summary>
    /// The test create signature fragment from private key excactly one fragment.
    /// </summary>
    [TestMethod]
    public void TestCreateSignatureFragmentFromPrivateKeyExcactlyOneFragment()
    {
      var privateKey = new PrivateKey(
        "DLGLSOAGKZTCOQYIDJMFVIEOLSDPMDOOGSJGRMQSFTONUNCKVTOEIWUOJYUGPADBAJJOZJYZXVTAUXFBBLHXCKHE9LXDMSFHHIACOBFW9DFVGKS9LWPHMWIKYGCEJHHMVVJPBGXWIMITNVZABFMWWORGM9NIVQFUWXKCWBHDJVYISCNINUIHLHCRAKEY9OLAJYHXVMRFKYPKX9EYULFOFNILGGPJPSPXELLJHAR9TRDUNEUNXOWUAAEXQELKSIYGFOTJKWNNZJWZGNVKJKOUJ9TASCHCCMVXKBZBFWMWTUXAUIEIWSLK9JOXVIJYKEO9QGFATLXICWHRFYMQTKCMPGUPWWV9LVZGSSHB9P9DVPHURK9QYXMNZLIRQPJNQGGJNXSYVZ9IFSXFWCKWSLDMZHDBFQCHDWYONHRVLB9XSQBCNAERNMHCZLXEDOEVYZUHP9QVITZR9EZLSSWKGLPIVTDWMXLXWDRFMKUYRDAQXBYUDZXICCJHLXIIARCAJZBLMI9NUZ9ZRYCUGNYLTRFP99XV9VVTOMIDFXHLLRZPKFNCMMNCSEIAHYCDVFQT9SVRUGIHAAPJMCAPAEZHNPOUHTJDDJKFHXTZEFAUFGBGTUVGTAETQMSDLQUKQ9OSKF9ZNKKFQKGABSUQLHXIYFOJGWYTEPNMVZY9OFROODXSHTNWCQIPODHLUOVHHBSZEOFXVDSYBIRLCTZ9ORGTMMEWMNAWATXZKAJGJMHFLIDIRAUJVWCIOEKWURHAQTNARUZIBROIEOPILKDXBFPGVCVMOFOQCUJUC9HFWNNYTPJWK9REHXGBGQFMXREPTJCMC9XOASZIKDMNOYEVABFKPFZ9VSIVFGJPMSDPCETDVBFVIOUFVBMYJLQKCCQQNBABTVGU9CUVUJCSUMYFSVJGOKVYHBEPCRQWIFLPHLNDLCOPOBWXV9NFDXDCVNM9OH9NTCGSYJINQZHWYPKDCQJTZOBDZDVHVRRDCFFMDTDCRXUMSYUEASDYVFSFNRSDDHAHCLBEXNXEYTSSDQVGNGCD9MBKFTHWB9PAXMVFVMUHAKCSUDTDXHPZRVK9BQHKLYJTKCDBEE9USUGPTJPEWKFGYSPHNZSLCYMTXQOAAXMO9YJGKYFIFBZZYHQXEDMXPDPQJWIYPTOAERJXLI9XDMEARFQBAAGOVL9EXWYHZAYHCAN9BYURDOPRLWWBYYBRUIAPCDDWOYYLWZJRXKSUFOPTYPUILVDZOLFT9HDBBNBNPLDUFVOVGLN9XUNDWZFC9LHJJESTWZ9CFPCLWIKLW9F9NUTLGLBOZFPWSQIDMF9GNVVXOGTJYKKIQTVHGCBCVQUANXYKSDYCEFGZZRDPWYXKXYQDJZ9LSZIUAGMHDIPUDN9NVBPL9PJVZAUOXVCENBPEQQSKIF9RHNUSHCWMRRYYDWXYUCJZUXYYPZVBUGKSFTRMDRCVIAFTFDHXIOMJUHMGNEBSCTMUMVRKLPYYKQZBADMVOMKX9Z9XFCGAYTRECALATWHCQXILVPBZUIADJWZUOBAVDADTSBDGPJXHYPWJVYZDZBKVHVUBGOPJTIKCGCEWABXSLGCTRBTCUCJ9CVFVIQXKLYQMPKRBIBRGKNTVJZBDINFELCNHHEXUNRVXMXXFFWGVJFCMWBZLKKRQDQMRCYLJXQGZZMBAJXDEZET9OHGKJDOAERIPBRVQCSMW9XECZSREEWXMEJNZDIYGBHICLWSRNEAXAVBPUENUKLRMGCRXUTROUDEXUNWYSPELLDJMKYNGVD9RKAABSXXKRNNIQRAWXWQJXDWLXCUWBOQHVUINIFZKDKMRHYW9KNJMDFIADXFML9VB9KVTWLYVULEVGUQZVZE9YODLRCOEZUMFVQA9ATBQVZHCQBLHFFPORVRODHIHYTHAAIZVFER9KXHXFUAQNQZGBFPWDOBIEUMHZAOXHSHCLSAXCVCIFIPGZUPIRLGKIEVEMGKHI9FTQZVEHVUVGZUMSHTU9JX9ULJJRBZWKMCGVNBXKTXTIJOLEKASDOUNFJJJYWRMQF9C9KVFZDXWRFYMRTAA9KG9MTKLSF9SRLPBUCSKEKOYIOVEMSONCNZWFLFSVJAHPWDXADSIGNTTWJTRCOJFHYFDBPQWWGVQSFGIVVSIMS9ATA9WYJTGGSUVZIZADJLBLEACFIBJJEG9OVNF9BZXEIA",
        SecurityLevel.Low,
        0,
        new SignatureFragmentGenerator(new Kerl()),
        new Kerl());
      var hash = new Hash("RBUEILZHMYBLXFXBZLASTGECTXQDWPXKNXCYXBQHASRRRLXBDUFYZNPLWKKQYAQYOVKWFKSJT9OXIUOWC");

      var signatureFragmentGenerator = new SignatureFragmentGenerator(new Kerl());

      var signatureFragments = signatureFragmentGenerator.Generate(privateKey, hash);
      Assert.AreEqual(
        "CTOJPGPVBRKWCAQGLAP9AFPUEYOYFPCFPTMGSDNDHWAIHCJYX9FYEBXOFGPVRVJOVXSMVQ9XQYZYAWDQAIORQUQHYHZGPHJLMRQNPCF9TTHBIJCJGKZFXKWEVBPXGJ9UDXODHZUYEMOYXZRGVEKWJWQPMNCWVWQAZCOVYRSUILQIA9QFVALNGKNWSVPHRZACGOPPVVCXSSEELHHFWIHDNBNDCN9SVHGAYWBYOUAMUOUJNIYAGCWA9CJPSYTMEET9SX9KVFHDMJU9UAKK9NPTWRLFTBYIQQNTLZPPTYGBJGUHJWMRCWXPXYKTMZDIUI9QBYMCOREOBPDPIDMIVUDKWUUSAMS9KK9QW9HTGBNNSJEUTKHNFNEITZ9VWKVKF9MEETRMGLVAJFCFZOPRVEINATBUFASC9VANASTKYXCSSBMMYISDQLSPSMREIQGIZANXVMPYFMYXLBYQGTZUEMXAOIFC9IJMPAFGXUJHFAMLBCICJFQLWOTAWUXGRZYEUPSDFXRKQRFDXHJEZNLKWNIAPA9JQCDDA9CBORNITROATPA9JKMVZBJUBKWNNYRZDYBMZ9NHHWUBIKKH9OTHSCMZCNY9FITUDEJQCY9ZELUAJSWKDNFPYKZKWZPSFADFMZSPPEZHTCKXBSUQLHXIYFOJGWYTEPNMVZY9OFROODXSHTNWCQIPODHLUOVHHBSZEOFXVDSYBIRLCTZ9ORGTMMEWMNAWAQYEJXHLHBXTRQMK9STZDWUSJLFCNJYPBETO9GOVTGGSSZWNNOJHCVVDWPJL9MTPO9V9BTUOSPJJOBBPEWVGTWTEKRXRUBCIM9RZJPURX9HGMWMPIFGULMK9JVOMQMWZCEPZINJZIVVEMZAPGTEESWYJZOXNGYGC9EC9QJPUJHULMKMVEK9NFUCSLCCWVZVTIJIVUOEYKAHLIEQFXGFPIPZYLWEHNHNKQULVIP9QNMRVYSRFEMHYKHTKYUX9CAQTAALGUVASCVPM9BQOOYKAPLRUGZQFWBKJNRHEJSRLMUZAKQPDOCCDOWJTHTCOEYIKPIRKCVHWSUKBQSORADFEWDNAUTHGYPPMZSURAQPHRNRRPKPBEAB9CXT9UDPUOGREDSSCUTFCTADIKVAQIYNHTXNDYCWGUSHCVLZUNQPCLX9WWTIHQEOLZTXHJGELVJBTATBDJAKLWSPNJCJWGQDPEBLLJSSJEOHSAFMKWZWCMIUNMULP9ESKUGHTJB9EHOEQXLWJEBZKHCHHOWQDJB9RCEGHJCWSVPWDEASHWBDBCXUSLFQGBDBQNMXXFEOWCWVXSLDPECJTAXVVZUONIBHYVQHDCEKT9MOAINWDIQCGDIKCSXKJWLXIOEKFIJUYXFQKYFZEZDEFCMTFPPEUTPIRIUSKSTTJKRCMPIAIIWELACCPMOJMUG9VBOUWAOQJSOHTAKYJ9XAXFBMFNZNCGXIHQVCO9D9XDROEMIVCNZLVYKLN9WFXFCDCTYIAAVIIBZSHJBURINSGVZLQEFDPKSFJETCJXIKYGH9VPAAPLNMPTHXXSHRNAPY9ZIAABAUATUBVGRTZWLFJREAAGUVQ9WDZLXMAFQODPUMRSKMVFRGVYKIYXOVNAZGDPYUJFM9A9NZL9SXK9BGFTJGYLOYMCUEZVYLBFYTSUYRRFJZUWYWPHXNHOCPHCNYKLEHAVPGBNGKNEUDBGTKPDOOGYTLMNQGQICYEFMLNKR9RF9PEZNSDRUKUTOSODIOACGIGYZCJYQFYW9HWHRAISDZDDAHUCVIUWYLKAEB9DBVTMFLQDUTPAMB9MXJ9RDJBLGRREOZYIHFHVRDECHZEDVWTMIKTZEQZWVQUWUYLPMPGTXAKDNOGFOQRKLZEKHJQJWHILURTBCUBMBX99AXIOVEWNQPJUPHLJLZUCPFNRBCENTWEVPDSMSHG9CKJSYOTRXCKYHKBKRRASMMMVGPNCPQAQMZJINHUSNBGKLDVRPOJTDWQXITBOBRYQXBPGSUCXOOTCBRESWRFSDU9DLCZPSUCQZSJBTYMPZQSVBKHE9DAYB9YKPIVLVVVRFGHZCCYWNOHVFGCWAFCAW9FPGNGFRS9WQKTIQBFHNIGRKYDOXMIGDLUOLMWADAENWMBYVWOCVTKOSDWMZLLRSLEPRJUDRIJMZFAOSLHFZGZVDPSPHHSWZFXNUGCWUVUWTPQPF9",
        signatureFragments[0].Value);
    }

    /// <summary>
    /// The test create signature fragment from private key excactly multiple fragment.
    /// </summary>
    [TestMethod]
    public void TestCreateSignatureFragmentFromPrivateKeyExcactlyMultipleFragment()
    {
      var privateKey = new PrivateKey(
        "DLGLSOAGKZTCOQYIDJMFVIEOLSDPMDOOGSJGRMQSFTONUNCKVTOEIWUOJYUGPADBAJJOZJYZXVTAUXFBBLHXCKHE9LXDMSFHHIACOBFW9DFVGKS9LWPHMWIKYGCEJHHMVVJPBGXWIMITNVZABFMWWORGM9NIVQFUWXKCWBHDJVYISCNINUIHLHCRAKEY9OLAJYHXVMRFKYPKX9EYULFOFNILGGPJPSPXELLJHAR9TRDUNEUNXOWUAAEXQELKSIYGFOTJKWNNZJWZGNVKJKOUJ9TASCHCCMVXKBZBFWMWTUXAUIEIWSLK9JOXVIJYKEO9QGFATLXICWHRFYMQTKCMPGUPWWV9LVZGSSHB9P9DVPHURK9QYXMNZLIRQPJNQGGJNXSYVZ9IFSXFWCKWSLDMZHDBFQCHDWYONHRVLB9XSQBCNAERNMHCZLXEDOEVYZUHP9QVITZR9EZLSSWKGLPIVTDWMXLXWDRFMKUYRDAQXBYUDZXICCJHLXIIARCAJZBLMI9NUZ9ZRYCUGNYLTRFP99XV9VVTOMIDFXHLLRZPKFNCMMNCSEIAHYCDVFQT9SVRUGIHAAPJMCAPAEZHNPOUHTJDDJKFHXTZEFAUFGBGTUVGTAETQMSDLQUKQ9OSKF9ZNKKFQKGABSUQLHXIYFOJGWYTEPNMVZY9OFROODXSHTNWCQIPODHLUOVHHBSZEOFXVDSYBIRLCTZ9ORGTMMEWMNAWATXZKAJGJMHFLIDIRAUJVWCIOEKWURHAQTNARUZIBROIEOPILKDXBFPGVCVMOFOQCUJUC9HFWNNYTPJWK9REHXGBGQFMXREPTJCMC9XOASZIKDMNOYEVABFKPFZ9VSIVFGJPMSDPCETDVBFVIOUFVBMYJLQKCCQQNBABTVGU9CUVUJCSUMYFSVJGOKVYHBEPCRQWIFLPHLNDLCOPOBWXV9NFDXDCVNM9OH9NTCGSYJINQZHWYPKDCQJTZOBDZDVHVRRDCFFMDTDCRXUMSYUEASDYVFSFNRSDDHAHCLBEXNXEYTSSDQVGNGCD9MBKFTHWB9PAXMVFVMUHAKCSUDTDXHPZRVK9BQHKLYJTKCDBEE9USUGPTJPEWKFGYSPHNZSLCYMTXQOAAXMO9YJGKYFIFBZZYHQXEDMXPDPQJWIYPTOAERJXLI9XDMEARFQBAAGOVL9EXWYHZAYHCAN9BYURDOPRLWWBYYBRUIAPCDDWOYYLWZJRXKSUFOPTYPUILVDZOLFT9HDBBNBNPLDUFVOVGLN9XUNDWZFC9LHJJESTWZ9CFPCLWIKLW9F9NUTLGLBOZFPWSQIDMF9GNVVXOGTJYKKIQTVHGCBCVQUANXYKSDYCEFGZZRDPWYXKXYQDJZ9LSZIUAGMHDIPUDN9NVBPL9PJVZAUOXVCENBPEQQSKIF9RHNUSHCWMRRYYDWXYUCJZUXYYPZVBUGKSFTRMDRCVIAFTFDHXIOMJUHMGNEBSCTMUMVRKLPYYKQZBADMVOMKX9Z9XFCGAYTRECALATWHCQXILVPBZUIADJWZUOBAVDADTSBDGPJXHYPWJVYZDZBKVHVUBGOPJTIKCGCEWABXSLGCTRBTCUCJ9CVFVIQXKLYQMPKRBIBRGKNTVJZBDINFELCNHHEXUNRVXMXXFFWGVJFCMWBZLKKRQDQMRCYLJXQGZZMBAJXDEZET9OHGKJDOAERIPBRVQCSMW9XECZSREEWXMEJNZDIYGBHICLWSRNEAXAVBPUENUKLRMGCRXUTROUDEXUNWYSPELLDJMKYNGVD9RKAABSXXKRNNIQRAWXWQJXDWLXCUWBOQHVUINIFZKDKMRHYW9KNJMDFIADXFML9VB9KVTWLYVULEVGUQZVZE9YODLRCOEZUMFVQA9ATBQVZHCQBLHFFPORVRODHIHYTHAAIZVFER9KXHXFUAQNQZGBFPWDOBIEUMHZAOXHSHCLSAXCVCIFIPGZUPIRLGKIEVEMGKHI9FTQZVEHVUVGZUMSHTU9JX9ULJJRBZWKMCGVNBXKTXTIJOLEKASDOUNFJJJYWRMQF9C9KVFZDXWRFYMRTAA9KG9MTKLSF9SRLPBUCSKEKOYIOVEMSONCNZWFLFSVJAHPWDXADSIGNTTWJTRCOJFHYFDBPQWWGVQSFGIVVSIMS9ATA9WYJTGGSUVZIZADJLBLEACFIBJJEG9OVNF9BZXEIA"
        + "TYROATEBPPDPENRWLMUZUZMCHOGKLPRWXDQIEEXVTXMJFPPFMOJAVBAGVKQODFINMMFQTBH9SBVPBG9XWMEMBR99J9LPHFGPFNJ9BPIIUZSJAUUFWETYQDMWVWOSMQKXPGODUJZHCVSDGWONTMJHJRWXPLWCZPQLLWLRZCXIWVOLBMNJGDIXTCKKAMLIHWQIRVDZFREMR99VOFYKCISIMYXGOAXKIREGL9IV9VCPUKTPBRLTRZDJUOIBSBHIEFMBETKAQJCOUVHGPOVKYWNHWBPSQOX9ULOOZEXLRESORBOPASFU9GWIPFEOIJBDITXQ99Q9PRFKJILNJMMHSPNYYOULOYBOVQCKSXPXKCORBZTBBSZTMEGCYNCIHDHTHMVQ9GCWTCKIKLPE9NDVGVGRWOIXPADNQPEODOUHMWPQTFKSPKKETIKUGAUSEPROOXPYGFOXLNOLNDFQCLNZENLBSRGVWCYOKCLANHAHJZXXRXQWYDCIISBIEDPWQUO9UDDIIQFXQTSDPTJVEVJPJOBMIIODPSDSTNBWLMJKJHYGRAXULPGKGWHWZOD9PUFYEEUORCZVJMKFGBQCSKILIE9SKXX9VNZAFKCL9IPWGAPKMALRSCOBURBSYFITFSV9SGFKQV9ZYZG9OZ9GXIABT9CRTTGLNIAEARKRPGVQAERBPR9UVMXXOGCJEVSJOFSVPMIRVXLVVMWHYUKGVZNACRVFFTKWDUZDM9FDYIFML9FENIPULPFUMWPXHTJGLHFLOQHNPUOBZUTZALZRYTUQAS9T9BVCDIKGAPMXZAKDNQRABCW99IBJTZXVGMIXQD9EJPAJFZFGNRJAZAYAZLNKJDBTYYCK9YHCF9AEVXZLMU9OEGJNYYLAXABHVG9LWOARSOAKDQCHCXGKKVSNXLEAKUST9RPJJZSHHD9WYBMAUYMVCHQHV9STPETDOOVCOSCEALLCUNVSKXZGQD99SKCZFGPFGWVOOFRXQVDGEQTAUTIXSMOAXLZKGLFVMP9UBC9PMYPEKGEYJF9EXPFRESBTFJMRNZQSGNBPDYEGYH9KMVRVNMIGVGGNBWMMLGPMNLTJXBJKRQ9YFKZHTAFZTXSMHCSLXTYISS9LZWUJ9BLWZYZTHEIPJWATFT9UPECRJDRYXQFZTURWZACRKRCIEHECLQZKVWMZEKGQSGBPUACDAVOT9BECXYPYUVEWK9CAMWUGNVW9YCPJ9XGIUNDSARJHQBQVZGQOYEFVTVVLYUFHLAIHUBUVXHWZD9IWMXSXJQDEHIHMFQM9MREC9ONRIGRBTVDJTJHQGBLS9QKZWYUDGDMLKAZGQFYUWRWPGAZSKBRHQP9MAYXWXTACDXZQCWKEPRLGNOSAEFPAWANDWEZCMOUFOQLTTUHMUYIPNUAEC9DXE9JDSEMAMTUDNDRXEAPWPSORBOHTQZCSUQQPBLEUJJBCMSKIBUSNAWWYMMPOLDAHVFFAPXVQFZMXOCQ9USMYCFYQGVBMCZWXFZCFGONIQFDVCRFMF9TQQLHEBQKHQAVJNRBJ9RDOMESQBULCLVBZJBEWEDYNCDADYJMTVRMJARSIUHUPZWBQCBVQEXDWREPFXU9ZEOL9RYCCWCKFTRWRDUACUAKLDHDCTA9SUYMBJKJH9XFPAYFHXWTTLHROJBQVBVMDUTUFMSUKKALWNRONHDWX9GIKZTY9DFAJMTMWZEUEDKFUNIVPLFOSPQYNVVPAYWALWOGOEEGNIMAUF9YCBSEV9DAHEJFCJPMZHZMHMBZJAEWQF9TFBKXSDB9VJDMAF9ODXUSWNZPBPNE9JOXIQCBQWNFQOTVAEPAJLWCYXRRXWRJTZRYQXYPHFKZVQAAPACHAABTZVEZFMO9HTKMWRXDHWZSKZBEROMAKXA9HARUCOUWJIIVQPGGTNZJQGRZVR9PCMUXMBKBGMJNTJHPGAOTJHMLWDGXBSCOEXODQXIRYRPMH9KLFIAJV9N9RQBMKNOUZKRYTGQBPXKEFIICTDTERMEMTAJXPWGIFAFLGHLQNYJLBNRHZTHUSLQGVTBOEDNVVTHTOR9KVDYGYA9KKEZRADZBJTYGFSBXADJMZMVJGQIZCJ9BPUJKTLISSPDVDIDREBCSQD9LSPFOQHXFTBNMFINXAZAITSWWLCZACBLIHEATPV9RYVFPQXIBXV9BGDKBVQT9PPFLDCKW",
        SecurityLevel.Low,
        0,
        new SignatureFragmentGenerator(new Kerl()),
        new Kerl());

      var hash = new Hash("UZOWRZHEJG9SZKIADSTRZLJSTKMJVPRLFKIMJCLYDKCZAQMMQYCQGTSESVDYSSWMEORCHQUSWMSCVPTXX");

      var signatureFragmentGenerator = new SignatureFragmentGenerator(new Kerl());

      var signatureFragments = signatureFragmentGenerator.Generate(privateKey, hash);
      Assert.AreEqual(
        "CTOJPGPVBRKWCAQGLAP9AFPUEYOYFPCFPTMGSDNDHWAIHCJYX9FYEBXOFGPVRVJOVXSMVQ9XQYZYAWDQAIORQUQHYHZGPHJLMRQNPCF9TTHBIJCJGKZFXKWEVBPXGJ9UDXODHZUYEMOYXZRGVEKWJWQPMNCWVWQAZCVLD9KZCP9FKKN9XXBCMHIRXFNAPVCOAAYL9RTRXZ9FMSTLKQGQONYFCTCPG9OMLJIIRNYCIIJDVNIRVIWODOPTSHXAEUORGCDLTSMDDVBTDCOFJYF9DUXOVNNCA9VFZWWEU9ASTFWIVJNTZS9HASM9TBPBOEMZGKHWTPXQNALQYFPEARAIMZFZO9UNEEBQNKJSPHID9WAHBNQMTJXPSS9HVETIU9QGEILEGBTAYSRSZBFIANFCZGWPZTJKNCBYZZYUAQSFGQWGYWPNSIFUSBT9BLVPZXDNGCQZULUMWBYKAH9EFUIMJHHLAROQ9BHVUETTOAQXMOVGPLGZKRQLASILJOJLUJPEQMJCWTUEXVODIQQJMKGJRMXKMXFGXAFHEDFHJSMTQHEFKMYLQFADIACRMJCT9BDKBGOCRJZRMSB9MLYRNENFAOLZCSDVYNJ9UTJGSNBCKA9JSSXAIAHZSJNNJTMTWAWKQJ9ETSEAHJX9NOPQYKLRUOOKCLJIX9WDIUKYBSPHRLMTHDSQLNLRFOIIPKU9YHQVWMXHMHYQHOTXQTUPKBALMMYCCOUDFFPEUTMOSB9PGOKCDMQPYPWBGBNH9LUNZDVGUPARXVHVQQWBIVMPOLVCUARCFPTFZUFELMTDWOYUBBQPARRQDORYRKPXBXMYTUSMIQLCDZRRWDDKYKHQMMIZZRAXSNXCN9EWJXJTSJJWQEZHKV9CAUENWJYQQVBXAGBJ9BDURQJDRANIHXZAHWDIXPCFCFVBIYOROVTWXVCAQEXELRFBMR9ACPSYKE9IRGMAFLQMLCOWIOLBDGCIVTKQJJITHDM9NQWKHKIBZXFGEDGNZUXVRHBCWOCOKKAYRKQPQVLEOSAYXHSNMMJGJXOSBNHMEMMNWQGHL9CBWYNGCTFLJGINWXDFWDVRUKGHBITMJBOHZRVAIZASXEIMNZXONPSGHXDIGFBNJLZEEWNJDGMSVYPOXSCYSBRU9VKIBNNOSNWFGGM9NQKZDKJMPCQBTVIMHSFNKAEQ9AZYFEFVMCS9BWY9ZNHJKVXPALOMYQXCPLR9YSEVMFY9NPXBN9GSQLJWQICAKUUPGBMPHHNMBBPEZCKVYIQUIOTQFF9XAQTGGHXAEBJVCRUILIFCYCKHOMDCKPUFOIJ9ZDQLUQBBMQ9VLVUSYJG9JEYPMLGQBRCUUWXHBHDMCUCMHDODAKYZQUMOLEUWUYGXWWBPXCEWGQUDAHTFYUUEIBVJJMQKNFFOGVOSTV9GGHGDXQUMTHQEDAFSNLBQRFKT99ILKBEZNFDYNUGS9DGABMCZQIPDFBHTSXBPQVCAJRRJSQGPPYDJ9QMRGNEWIHTBHHJGVSWQDQOCRHDDOZGRONFXKVKJNEMDMJDERYTQJTSEBKLZXURIZHMAHCVBCTBDVRSWRSJBYDATBIRGHQHNGJVBGDPCAIWCWRDDLCWZY9YBPQNW9XAYAB9IODFEMXAMKXIBPKCZR9KEGDRDXFNXIDELDTWNX9ZI9WVXLBXHYZF9SGESYQHPFHSEMTVL9ZQLCMGOYQRKWUNMCALUWVUKVGVPSMAKIHXJCL9STBTMJZUELLXJWMCBMALQ9TWWRWOSVIKGMSZNAPSWEOWXXEGQWXT9YOVU999ROFWLGAGWORMNKZDDHMMWGGWUMBYWGMZKKDKYPLJTDXIF9RGPPWAGQARTRZYUPHZ9WFSAIDDXPVAUEGVTYRZNLONVVTFNEHTHUZFMGMW9XLWKGZUFODCPLPYCJTCZKCFYLFISHSEPULTYBOCIGQWIVVWZSMMMVGPNCPQAQMZJINHUSNBGKLDVRPOJTDWQXITBOBRYQXBPGSUCXOOTCBRESWRFSDU9DLCZPSUCQZSJBUBFCQOJIDINSAZCWVPBKQMPDYQJZPCDDHZAHFYGPWE9SDXCJPPIFIXGDJFMJDSCVCTEZKWMLSMPPBDTACSIGNTTWJTRCOJFHYFDBPQWWGVQSFGIVVSIMS9ATA9WYJTGGSUVZIZADJLBLEACFIBJJEG9OVNF9BZXEIA",
        signatureFragments[0].Value);

      Assert.AreEqual(
        "JSXILDFXAY9DOLCZJCPVOWYYXYWJDWEHKRRVRLZYSWYWPCGGOMDELWIXFLCRXIZVCWPXOZGBZUHD9M9C9A9SHFFLHECGEEKSFEA9ALXJRMCCMVHJCDZGVRSZQ9XJWUPJJLEJBXQIFPPYJNLXUXTX9ARE9FNCBOCUPXBYIGONUHAVZUJBXVBLTUYBBCZFHU9VPNUHKRDRDKW9XNJBFWWLBSLUCNTQXPBIQUHYJTSZSWSEJSLQYCCXGETLMNTBUXNHXZOJPNPJLVDAK9KKVUVNOKM9RJDJAEIMQNYEQGVGVKMGQNIVYWJWCFEUVEOHPLMFJBD9PLTHQEKVSKHEOHSMWTPPFUKHGBOOHUMRYCTEPNYCTIWOCETXZPTHBBEYLMGCTMOOSWQND9SWBJFTXDDHCIGZZVCNIXTVFRRTKIPKSSIABWJUHGIR9VIAXO9GLRSYVZBVEWBXRKTXIPLWVVXGTBJQEDISVSPTXHJBC9ZGIKEOZTBWAJROFDFAHRL9EVOGA9UOCTSVFWHCKHNGRGX9DBWZFXLLPKOUJZFKBNOSCJEYTFLSQIJQIADUCCWA9NJTPVXJZTENNRHDNVZMJKPUNUSCEGFPXPUXGWR9OZNSFGGLRBJOVGU9OPMGBEGSMZOUGLUVZFBDOZ9GXIABT9CRTTGLNIAEARKRPGVQAERBPR9UVMXXOGCJEVSJOFSVPMIRVXLVVMWHYUKGVZNACRVFFTKWDNJXYIHXYMOSWGHUDTI9PKACNCVYSXXGKPAR9ALAOHDHAKVXRYFCTGSJGRVDMNIMXDYDFX9MIQXOSCCIQXVLQQQSLIPZ9LRHAVPIP9I9JQNB9JTMPHCVFSUDX9PUFMGUFRAURBWVPMBD9BOQSATSXAHNEIBLLENWFEYFMAPBILCRB9TJYUCXUFBEFDYKTARPDFIETNEHPBJPYBJTPQLORAWDBPBGKGBOZLYYWWLEMBKEIEVFTTSWRSKHSGDWPNWOMETSVSVVKJF9OLOR9KYZEXVMPIMB9FGUZOZHVVNFZEMFUCTMOKMRF9TVJYKNYYKT9WUSWUGCSCEUYNWIWER9JPMJASCLLQKQUHIHCMLQBCXWGMEEZIBJQDQLNVVOSLDF9MKCMDNAGEE9BHXVHCKFE9ELEKVAJQYJZ9NEMSVUFHPYSZWJOWRVHYBQEMVWZLHNOABWXXVLVXYHBBLFEDSHRPOMPVBXWWIWRDLTUGXRTTTPOUGFAF9ETTYIEOSJSNDFVYYIXMQMBEYNT9OQIWBUY9JQSFMMXYI9LVHNK9HOJUSJBPQVSZQDJWTWYV9SLZBWMQFLXFLAEIHTHBPMNOTCQZFAU9IONETTAOYQUECUHETGKFODFPEOTURPDUELMNCHLMXGEGGFBVQR9T9RDYKSXPMLTSSCHMSGJMAHDORNE9OFLBYVTDAPQCCYIFAXXNXQGXDRINIHSQC9GHJCMAVCGAAIBYCIXYRIHQPUKAWBJDUXJEGHUDRAXPGEH9UH9WSRKERDZIOBBOCUEHJHQGKYR9WSGUBFRZLKPISXCFNWVBXOMESQBULCLVBZJBEWEDYNCDADYJMTVRMJARSIUHUPZWBQCBVQEXDWREPFXU9ZEOL9RYCCWCKFTRWRDUACUAKLDHDCTA9SUYMBJKJH9XFPAYFHXWTTLHROJBQVBVMDUTUFMSUKKALWNRONHDWX9GIKZTY9DFAJMTMWZHRDVJVBLYDFHV9JXVUNHAPTZENYCMGAOBTSTFKFN9XAFUITLIKPSNXQZYM9MVTTBW9UDKRXZHGFCJII99DMBHYOSIHK9JHLPNNLPGMCCXFHOPEEOIPLBNOIHBGIQU9AQYYMPYRHIELIQVNMRPKTLTXYQJNQ9POVFNCWFNSSUYOOQJ9ARNUTCJEGTXYITAGHPBXTCGQUMOVYVXN9VEPIHWMKHNUOMWWJVFYIGALWEWHHW9PQPLDDSCKFZCCNGSJWOGZOHOVENOBDRHPSPN9QG9SDJSGLREAHXAQHWGTXJY9KIP9IPXAXIYKLZGVARVMHJNRFDVHQOBBQAGOOIVYQSYXBPCKXSCHAZPKPRPYLUXJEPQROFXHAHZKPKDEDINBMBM9RATOYBZAMOCPGLMDOZWRASAMOQXACRHCXIW9MUZLXDNYQSJTNWRDJKPIAIAYFAQFQHVONXMBXYBCUMCSQZRMEYXYFZOINITZHJXB",
        signatureFragments[1].Value);
    }

    #endregion
  }
}