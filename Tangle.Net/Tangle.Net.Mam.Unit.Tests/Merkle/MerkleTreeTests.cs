﻿namespace Tangle.Net.Mam.Unit.Tests.Merkle
{
  using Microsoft.VisualStudio.TestTools.UnitTesting;

  using Tangle.Net.Cryptography;
  using Tangle.Net.Cryptography.Curl;
  using Tangle.Net.Entity;
  using Tangle.Net.Mam.Merkle;

  /// <summary>
  /// The merkle tree tests.
  /// </summary>
  [TestClass]
  public class MerkleTreeTests
  {
    #region Public Methods and Operators

    /// <summary>
    /// The test get tree by index builds new tree corretcly.
    /// </summary>
    [TestMethod]
    public void TestGetTreeByIndexBuildsNewTreeCorretcly()
    {
      var seed = new Seed("L9DRGFPYDMGVLH9ZCEWHXNEPC9TQQSA9W9FZVYXLBMJTHJC9HZDONEJMMVJVEMHWCIBLAUYBAUFQOMYSN");
      var factory = new CurlMerkleTreeFactory(new CurlMerkleNodeFactory(new Curl()), new CurlMerkleLeafFactory(new AddressGenerator()));
      var tree = factory.Create(seed, 0, 10, SecurityLevel.Medium);
      var treeFromIndex = tree.GetSubtreeByIndex(5);

      Assert.AreEqual(
        "GMUKQWQQMWRJKDIKMUKWUEBVT9OVWJTQYBPWFZQWTPXM9X9PHRMGD9ZXX9HMEWQMNZHIONHPYKMILJNPXWQQULUEOSDTBASXMIUWJPISMLS9LTJBPMQE9UMQPKBWTHBAPOGTUIZMELHKKWSWQSJBGXUQQOQCGAIJFAMALSGAUMXXOUTXAEKOAZIJM9A9OFPZGHTYBLTU9WNPXUUNLTOSRAZHQTCJZXOUCDLFLKZCGAUSKUJ9VOZF9FYWGQSQPKQLDVWSNQNLHWLPFPVRWKBZL9ENZQLVADTQATEKDQLYKLAVQPTOFZ99IUKRFJUYBGVYRKD9E99QEXYZINBAFBXIRTUKBNNPRLEZZMGTPMINHMJHQNAQHBTTWDFJXCXYEWKODJQBPUDQEVPWLKIZLACYWAHMRIBRPBNZCWVTUL9TMCRFCQKIGPTFUAC9RUPMRV9BHKODHACGASJMXWHHHNAHFXMOEBBPRNYCUHNRH9YDSRRNKCLFQACABEIYLOEEMHZNQRMCBPNIILHSYEWUOSWPU9ULFACUHGBKCAKBMTGVVTREQKRMTHKRKUWNV9AFMAAKULKREWTUZJFEZKEEO9SGTJWLDUZHLXKQOJXNERMFURE9PHFJRBVUUJUYB9ZPLKWJPOMJTQZCWPJDDRIXLKFAJVSSTEMQYFSGDDBRTPWYJUYOCFDAJAWLQSKWZ9EHLDXPCLNNIWQCMBKIPNOESLBRFUTECJZWKXE9VPJKASMTBKVLJXFUDQSTDQANPUCTPBGCVW9XLLVYTRR9UJZQALAXTHOQXMWGX9EXSENEQBTEFZVR9GCZDDTAIGIYRJVI9DGNG9WHACA9UQFZJTOGVFYMLPCHJRNNEDTMMOCVTIFXYFDWMJLDIKVCL9HSIPAOUEFPCS9IQCNERPHWYTRCCTBMJSEYHXFMM9DX9VBTLLQRIRWGCWEBRHLK9BHBGZAYDSTLGRAXJQGYJUECBCZJTIKSZFIIOURKOHUWSXYOHKORKEOZIXROQZHKCQELEIVRWZKQWT99FP9DKFFHIMUT9PL9OSOXJT9XWW9UNADHIYORH9VRVF9UDKKNNMYTUOPDKVGIZ9FVRGV9OINOHWVOSMOIAAIBYWKIJDLBBLRSVP9SZHSTYDQUETMYJEXPNOONUHB9WDLFYZOKBSO9DFPIDERXPXLOZAMSHTVRBJULQQHOPTEBLJICEQVD9PALF9P9AQWHPFJPTTNXYE9Q9FMLNAMZKIWWJLW9BPNRFOIQLAIRORBONKUUFACDHOODFFHDPBCYS9TLMN9NMWMEUDCWK9DUQZLFPFMIWMCIJFLXMPEL9BRS9INSCHRNXKOWVUH9XMCIRAMNADVHBQKXQNLURJZPLUGKMDEZDZTIYCTLSEJZBTTAACSOYIADYOSQWGVKWABLAGTILQECUHAO9ZJUVTRIYR9NP9FVQVZYYIIFTOSGPYVNPE9PPZSFNKLEWANHMTDZMCMWET9LQCRC9JPRVLLNJGTUACADJRVPFWNZTVFOKRHMHHQBDNOCIWDUKJBYFYK9FVDUSDXKUMKZLENAULKFHXJ9KLUCWALKXAOBQEMBWMPWQTOOCHVCJRIQ9FHXMYBWKUEQQ9A9EJEIQLYOYAZWUEPIBQJNGUIYQPSTZHKDAKKEZCIEFJZK9HPRXGJ9VZJKWCFOGZQDLDKTFJFPUQCNYV9IVZTTFURZDTYUXUNSKHEYIWNQWWEKXRJSFEA9TIYLHSXYPOFUPPCTMECZLEBIZVCTCUJGEGSOOQEMUKBIYAPCYDQWDWKT9XAQTKHZOOWOHPJB9DWQQGBBPTAKQAGQLIGMQKTKTHCSGPXJIGACIWIXJEGEHCYKWRUERUYREW9EAFBHYUZZAKFICBOXJMCDCWSVBRL9MCFGCLZSKYXKTNQLBUD9GYWLVFVBLKJWJHQUWKZBQNBNJCAOLDIAXSHIREODQPIOTRJZHSGBHVP9YBSOWBSNKBSFJIIQKACAAPHBORBVD9QGDDTKAHFEMALXXWJPIBRDBTXTEFGYANVMXCEPGSOEBHNFI9AVTKFUY9CKTKBJ9PFKERJFJKXCC9IFXVOYDGSJRUZWMP9KVULNYIWK9WIAANDIBZBZWDDO9UZXENUXKWJRWWUHGRYGTBJXDPMZKEVYJKQBMZWSDRE9JLDMVCKTMDCOUUE9PLWYWII9KGTPSVYPMOBMNCUAWMBGPRJTIDRWKHJYRCOSCVZBHFZREIFYAVSGWDOUKCVQCYLINTLDDSDTC9EMSLZATSKLHVUSMHA9BOCIMISMDVUIEHGNOYMYFSWB9AYFNTHEFBF9RZCIPVMMF9UIRG9QYNSRXYHKRMTGVV9OSMHKTTN9B99GCBPKBEUZHHMMBXCSAPDKXXWIVUOPUGYYQLCUWHECILFNKYTGLKSWMFPMUTXOAHIZQRJJDI9YOPWHYJDPECH9TQHBBXAYKLVJZPSEUHBMSOGYTBOJAN9PNNTBQGGLJUDIWCWSLE9PSOTBXCISENCTYEPEUNGJNQL9NKCRECAVGUGUR9V9RORGCHGZNR9MXCKYIJDXLZUZLAERRZUONDKDWLLNOPSPVLRIXIQPZIVHXBSDEXHINKMWFUZEJCZCAGJYQIBXDJXHOBIWBELRMFOZIDMDUQRBOBPTOZVLXPHVVGRLOX9QXMZPJNE9WPLMLLJLPTJQAEEHF9XNSEAELJVTGSFOWTSITBSKALGMQBFO99TRHK9WSTY9LXDEQCYNCHTPHZXTYOIHGWBFUWFSQACUDZQIKCLNOVJZ9UCRTOYDPECYWIHRASMBYYH9S9KNPCZHUGHIMETZSAUKUXFGGFSHQPUIMBQUQULUWBGMPNXQVEE9NZGUXFBJBIBRSBJLPHBLWU9SUJYHIMZWXIISCCI9GSGRKC9PX9UFEPVSJZSUMXMGMHLERSEBSTQWTZLZGHTDZMIMUFIOW9RCSDMXDSEGSICZWMDVXIOBBRRBS9QYI9YOHDROGOOGQOSPQKIXSCPNNDLQCMPWAMD9DXOITSOKOOLHLCPHOKHJEGDASGOKNADTLAJMSBEFREBOGLKFUWSHFJEJXMFLYWBZG9VXUCEJGUBKTZTKNILTRAKISERYFJOVPQPPQLNPWLEXIFISFTAQ99KMQDFEUYIQUKZASMTZPFHQBIBF9MRRUTPZCLFRUZYX9YTTERTPUIZACVXCOWFFVLHZYMYDWSRDKDIXZODW9OHKQ9BEEKCQQI9BOJSPSKBYQCGTJHKJFZFMFJ9YGNQVLVOBXVNFNBQUBBCLGCUYFUELBRGGGFXMCHCYUHXTMXMUZGGSBVYIQOOYFCVHOQVEOCQMMQPLERW99EEPSICXRBLFJWMGBOXZYWZBMSLKNPHWSQNFFFABMLKNXRDCFYTQKBFISYXNEJRS9ABKFDGJ9NMVTYWGLCYQNCYRVPWNVQWJUUTTLLETE9TNZMXBGBXQTWJFZGIPEJMMV9JVSQTHQWFRUUMQBWVCPSKQEFMTBANRERBIAYWY9BSKOPOEH9FPRNLZVJJ9RSRACKZSVGWMWRKCBU9VVKVGFNTOGWYVFFBEAAATPFUTDSNKHTFCLFYXJMVNMZRWOTVWHFULAKBZGXVHAJVCEUM9AEEULZCCINCOCRIJUDTATGOHMIDRVAYVOSOEQTCKTCXGGRTEC9AHJCRNFAZIWFVREHDKULEX9FFUREHOXT9XCWQUAQSFB9GRPDRKLSFLCJPPEGEBGVONFPWFHUGIXKNC9AAMIUZNZLSDBPQIDDDM9ULAZJUZAPQSBPOPWSBPNYPC9CABQYSHDXEG9GGQIZEZFGAZOPDGDZUDWTSENCCSLMWDUQPCGZMRUNWJRHMHJFVBZLWRCTIJMJISHFHMLWGIPKWTSTHGJJSZPTIFQPVCQEZDHIEKZQVJSGXYNBALCVOKYNRIWDDLCSPWISUMBJPOFXDZJUN9VEYPBGICMRIIPYXDBKVO9XBECHOLBBQWICDMUBXHIWSSZUYIV9Y9RTKRHZPSHKCU9LOXTYUHDWJQIFBWWFHQVUVG9VNWRZNTOAGTXESDFHAGOAMHGVQA9NSUDU9WYCCGGTJBEVSRYZGDWBHFUXVOSCHRUNS9JAYZLFMUFNKTKMGD9QZMZIVTPQUTRRYKGWVEYMCGKMOVMAC9LJDRVLKXRTNHBUU9LMMVCFAVJOIMDVFNIPZVTSZQWWTEBXHZQWE9TDBCUVX9YHICGJK9OMNEZFY9ZOORVZGZVXCSTOBCZVGTBGBBGILMRAYEQKBYPOVJXAS9DQCKCWOTMJSLVHCWXFQNJEZIQUQACYVPPBFKWZVLPIGWBYYNJKXVSDUTY9AESLVUGFREDSJLJEHNL99THPWAVCJIREAQFRYZKPL9CCVAXLLGOVEINGOQKHKDHIPMRZ",
        treeFromIndex.Key.Value);

      var merkleNodes = treeFromIndex.Leaves;
      Assert.AreEqual(4, merkleNodes.Count);
      Assert.AreEqual("QKNPTETOXQRZYVSCYOTNRZFGKGGMIPYTZARBTZIOMULXWNTXKWIRQEL9JFDKLPZYZNNBQAXNBNX9DFNSD", merkleNodes[0].Hash.Value);
      Assert.AreEqual("NXSMQXNPJMBECTBQQFYYPHXBHXJEKEJAHMWOCHOOON9ZBDSECWQLPSIMQTYZQBWDVMTYEZLXHJZSYJH9E", merkleNodes[1].Hash.Value);
      Assert.AreEqual("NVPRSBAZVMYYOLVKWPSZIAECBRINZ9CXWBGYVPVCVYLXOBUIJWXPUSOCTHQOVYFHKUFHCCKHWAEQPIRKD", merkleNodes[2].Hash.Value);
      Assert.AreEqual("VTGYAQMLCYKTXBYNDKHCHJFWDFCPHO99GRMJVEVPOEWQPHJWDUJ9YBOBDNAQBSFKFHWFDDMCECHITZAKK", merkleNodes[3].Hash.Value);

      Assert.AreEqual("QKNPTETOXQRZYVSCYOTNRZFGKGGMIPYTZARBTZIOMULXWNTXKWIRQEL9JFDKLPZYZNNBQAXNBNX9DFNSDNXSMQXNPJMBECTBQQFYYPHXBHXJEKEJAHMWOCHOOON9ZBDSECWQLPSIMQTYZQBWDVMTYEZLXHJZSYJH9ENVPRSBAZVMYYOLVKWPSZIAECBRINZ9CXWBGYVPVCVYLXOBUIJWXPUSOCTHQOVYFHKUFHCCKHWAEQPIRKDVTGYAQMLCYKTXBYNDKHCHJFWDFCPHO99GRMJVEVPOEWQPHJWDUJ9YBOBDNAQBSFKFHWFDDMCECHITZAKK", treeFromIndex.ToTryteString().Value);
    }

    #endregion
  }
}