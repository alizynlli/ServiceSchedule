using System;

namespace NBA.ServiceSchedule.Core.Models.DAOs
{
    public class ClientAccountOperationDao
    {
        public ClientAccountOperationDao()
        {
            cha_create_date = DateTime.Now;
            cha_lastup_date = DateTime.Now;
            cha_tarihi = DateTime.Now;
            cha_belge_tarih = new DateTime(1900, 01, 01);
            cha_fis_tarih = new DateTime(1900, 01, 01);
            cha_reftarihi = new DateTime(1900, 01, 01);
            cha_vardiya_tarihi = new DateTime(1900, 01, 01);
            cha_ilk_belge_tarihi = new DateTime(1900, 01, 01);

            cha_special1 = string.Empty;
            cha_special2 = string.Empty;
            cha_special3 = string.Empty;
            cha_evrakno_seri = string.Empty;
            cha_belge_no = string.Empty;
            cha_aciklama = string.Empty;
            cha_satici_kodu = string.Empty;
            cha_EXIMkodu = string.Empty;
            cha_projekodu = string.Empty;
            cha_yat_tes_kodu = string.Empty;
            cha_kod = string.Empty;
            cha_ciro_cari_kodu = string.Empty;
            cha_srmrkkodu = string.Empty;
            cha_kasa_hizkod = string.Empty;
            cha_karsisrmrkkodu = string.Empty;
            cha_trefno = string.Empty;
            cha_diger_belge_adi = string.Empty;
            cha_uuid = string.Empty;
        }

        public short cha_RECid_DBCno { get; set; }
        public int cha_RECid_RECno { get; set; }
        public int cha_SpecRecNo { get; set; }
        public bool cha_iptal { get; set; }
        public short cha_fileid { get; set; }
        public bool cha_hidden { get; set; }
        public bool cha_kilitli { get; set; }
        public bool cha_degisti { get; set; }
        public int cha_CheckSum { get; set; }
        public short cha_create_user { get; set; }
        public DateTime cha_create_date { get; set; }
        public short cha_lastup_user { get; set; }
        public DateTime cha_lastup_date { get; set; }
        public string cha_special1 { get; set; }
        public string cha_special2 { get; set; }
        public string cha_special3 { get; set; }
        public int cha_firmano { get; set; }
        public int cha_subeno { get; set; }
        public byte cha_evrak_tip { get; set; }
        public string cha_evrakno_seri { get; set; }
        public int cha_evrakno_sira { get; set; }
        public int cha_satir_no { get; set; }
        public DateTime cha_tarihi { get; set; }
        public byte cha_tip { get; set; }
        public byte cha_cinsi { get; set; }
        public byte cha_normal_Iade { get; set; }
        public byte cha_tpoz { get; set; }
        public byte cha_ticaret_turu { get; set; }
        public string cha_belge_no { get; set; }
        public DateTime cha_belge_tarih { get; set; }
        public string cha_aciklama { get; set; }
        public string cha_satici_kodu { get; set; }
        public string cha_EXIMkodu { get; set; }
        public string cha_projekodu { get; set; }
        public string cha_yat_tes_kodu { get; set; }
        public byte cha_cari_cins { get; set; }
        public string cha_kod { get; set; }
        public string cha_ciro_cari_kodu { get; set; }
        public byte cha_d_cins { get; set; }
        public decimal cha_d_kur { get; set; }
        public decimal cha_altd_kur { get; set; }
        public byte cha_grupno { get; set; }
        public string cha_srmrkkodu { get; set; }
        public byte cha_kasa_hizmet { get; set; }
        public string cha_kasa_hizkod { get; set; }
        public byte cha_karsidcinsi { get; set; }
        public decimal cha_karsid_kur { get; set; }
        public byte cha_karsidgrupno { get; set; }
        public string cha_karsisrmrkkodu { get; set; }
        public decimal cha_miktari { get; set; }
        public decimal cha_meblag { get; set; }
        public decimal cha_aratoplam { get; set; }
        public int cha_vade { get; set; }
        public decimal cha_Vade_Farki_Yuz { get; set; }
        public decimal cha_ft_iskonto1 { get; set; }
        public decimal cha_ft_iskonto2 { get; set; }
        public decimal cha_ft_iskonto3 { get; set; }
        public decimal cha_ft_iskonto4 { get; set; }
        public decimal cha_ft_iskonto5 { get; set; }
        public decimal cha_ft_iskonto6 { get; set; }
        public decimal cha_ft_masraf1 { get; set; }
        public decimal cha_ft_masraf2 { get; set; }
        public decimal cha_ft_masraf3 { get; set; }
        public decimal cha_ft_masraf4 { get; set; }
        public byte cha_isk_mas1 { get; set; }
        public byte cha_isk_mas2 { get; set; }
        public byte cha_isk_mas3 { get; set; }
        public byte cha_isk_mas4 { get; set; }
        public byte cha_isk_mas5 { get; set; }
        public byte cha_isk_mas6 { get; set; }
        public byte cha_isk_mas7 { get; set; }
        public byte cha_isk_mas8 { get; set; }
        public byte cha_isk_mas9 { get; set; }
        public byte cha_isk_mas10 { get; set; }
        public bool cha_sat_iskmas1 { get; set; }
        public bool cha_sat_iskmas2 { get; set; }
        public bool cha_sat_iskmas3 { get; set; }
        public bool cha_sat_iskmas4 { get; set; }
        public bool cha_sat_iskmas5 { get; set; }
        public bool cha_sat_iskmas6 { get; set; }
        public bool cha_sat_iskmas7 { get; set; }
        public bool cha_sat_iskmas8 { get; set; }
        public bool cha_sat_iskmas9 { get; set; }
        public bool cha_sat_iskmas10 { get; set; }
        public decimal cha_yuvarlama { get; set; }
        public byte cha_StFonPntr { get; set; }
        public decimal cha_stopaj { get; set; }
        public decimal cha_savsandesfonu { get; set; }
        public decimal cha_avansmak_damgapul { get; set; }
        public byte cha_vergipntr { get; set; }
        public decimal cha_vergi1 { get; set; }
        public decimal cha_vergi2 { get; set; }
        public decimal cha_vergi3 { get; set; }
        public decimal cha_vergi4 { get; set; }
        public decimal cha_vergi5 { get; set; }
        public decimal cha_vergi6 { get; set; }
        public decimal cha_vergi7 { get; set; }
        public decimal cha_vergi8 { get; set; }
        public decimal cha_vergi9 { get; set; }
        public decimal cha_vergi10 { get; set; }
        public bool cha_vergisiz_fl { get; set; }
        public decimal cha_otvtutari { get; set; }
        public bool cha_otvvergisiz_fl { get; set; }
        public byte cha_oiv_pntr { get; set; }
        public decimal cha_oivtutari { get; set; }
        public decimal cha_oiv_vergi { get; set; }
        public bool cha_oivergisiz_fl { get; set; }
        public DateTime cha_fis_tarih { get; set; }
        public int cha_fis_sirano { get; set; }
        public string cha_trefno { get; set; }
        public byte cha_sntck_poz { get; set; }
        public DateTime cha_reftarihi { get; set; }
        public byte cha_istisnakodu { get; set; }
        public bool cha_pos_hareketi { get; set; }
        public byte cha_meblag_ana_doviz_icin_gecersiz_fl { get; set; }
        public byte cha_meblag_alt_doviz_icin_gecersiz_fl { get; set; }
        public byte cha_meblag_orj_doviz_icin_gecersiz_fl { get; set; }
        public short cha_sip_recid_dbcno { get; set; }
        public int cha_sip_recid_recno { get; set; }
        public short cha_kirahar_recid_dbcno { get; set; }
        public int cha_kirahar_recid_recno { get; set; }
        public DateTime cha_vardiya_tarihi { get; set; }
        public byte cha_vardiya_no { get; set; }
        public byte cha_vardiya_evrak_ti { get; set; }
        public byte cha_ebelge_turu { get; set; }
        public decimal cha_tevkifat_toplam { get; set; }
        public decimal cha_ilave_edilecek_kdv1 { get; set; }
        public decimal cha_ilave_edilecek_kdv2 { get; set; }
        public decimal cha_ilave_edilecek_kdv3 { get; set; }
        public decimal cha_ilave_edilecek_kdv4 { get; set; }
        public decimal cha_ilave_edilecek_kdv5 { get; set; }
        public decimal cha_ilave_edilecek_kdv6 { get; set; }
        public decimal cha_ilave_edilecek_kdv7 { get; set; }
        public decimal cha_ilave_edilecek_kdv8 { get; set; }
        public decimal cha_ilave_edilecek_kdv9 { get; set; }
        public decimal cha_ilave_edilecek_kdv10 { get; set; }
        public byte cha_e_islem_turu { get; set; }
        public byte cha_fatura_belge_turu { get; set; }
        public string cha_diger_belge_adi { get; set; }
        public string cha_uuid { get; set; }
        public int cha_adres_no { get; set; }
        public decimal cha_vergifon_toplam { get; set; }
        public DateTime cha_ilk_belge_tarihi { get; set; }
        public decimal cha_ilk_belge_doviz_kuru { get; set; }
    }
}
