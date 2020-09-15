namespace HWCAL
{
    /// <summary>
    /// The configuration of the HW channels
    /// </summary>
    public enum HWCAL_CHANS_ENUM
    {
        Hwcal_chan_PORT0_CHAN0_idx = 0,       /* 0U */
        Hwcal_chan_I_A_TLF_5V_STBY_idx = 1,   /* 1U */
        Hwcal_chan_I_A_INV_CUR_U_1_idx = 2,   /* 2U */
        Hwcal_chan_I_A_INV_CUR_U_2_FUSI_idx,  /* 3U */
        Hwcal_chan_PORT0_CHAN4_idx,           /* 4U */
        Hwcal_chan_PORT0_CHAN5_idx,           /* 5U */
        Hwcal_chan_PORT0_CHAN6_idx,           /* 6U */
        Hwcal_chan_PORT0_CHAN7_idx,           /* 7U */
        Hwcal_chan_PORT1_CHAN0_idx,           /* 8U */
        Hwcal_chan_I_A_TLF_5V_COM_idx,        /* 9U */
        Hwcal_chan_I_A_INV_CUR_V_1_idx,      /* 10U */
        Hwcal_chan_I_A_INV_CUR_V_2_FUSI_idx,  /* 11U */
        Hwcal_chan_I_A_BRD_TEMP3_idx,         /* 12U */
        Hwcal_chan_PORT1_CHAN5_idx,           /* 13U */
        Hwcal_chan_I_A_CTRL_REV_IN_idx,       /* 14U */
        Hwcal_chan_PORT1_CHAN7_idx,           /* 15U */
        Hwcal_chan_I_A_U1_TEMP_idx,           /* 16U */
        Hwcal_chan_I_A_TLF_5V_T1_idx,         /* 17U */
        Hwcal_chan_I_A_UZK_P_idx,             /* 18U */
        Hwcal_chan_PORT2_CHAN3_idx,           /* 19U */
        Hwcal_chan_I_A_V1_TEMP_idx,           /* 20U */
        Hwcal_chan_PORT2_CHAN5_idx,           /* 21U */
        Hwcal_chan_PORT2_CHAN6_idx,           /* 22U */
        Hwcal_chan_PORT2_CHAN7_idx,           /* 23U */
        Hwcal_chan_PORT3_CHAN0_idx,           /* 24U */
        Hwcal_chan_I_A_TLF_5V_T2_idx,         /* 25U */
        Hwcal_chan_I_A_UZK_N_idx,             /* 26U */
        Hwcal_chan_I_A_INT_12V_idx,           /* 27U */
        Hwcal_chan_PORT3_CHAN4_idx,           /* 28U */
        Hwcal_chan_I_A_BRD_TEMP1_idx,         /* 29U */
        Hwcal_chan_PORT3_CHAN6_idx,           /* 30U */
        Hwcal_chan_PORT3_CHAN7_idx,           /* 31U */
        Hwcal_chan_PORT4_CHAN0_idx,           /* 32U */
        Hwcal_chan_I_A_3V3_idx,               /* 33U */
        Hwcal_chan_I_A_INV_CUR_U_2_idx,       /* 34U */
        Hwcal_chan_I_A_INV_CUR_W_2_FUSI_idx,  /* 35U */
        Hwcal_chan_PORT4_CHAN4_idx,           /* 36U */
        Hwcal_chan_PORT4_CHAN5_idx,           /* 37U */
        Hwcal_chan_PORT4_CHAN6_idx,           /* 38U */
        Hwcal_chan_PORT4_CHAN7_idx,           /* 39U */
        Hwcal_chan_PORT5_CHAN0_idx,           /* 40U */
        Hwcal_chan_I_A_1V25_idx,              /* 41U */
        Hwcal_chan_I_A_INV_CUR_V_2_idx,       /* 42U */
        Hwcal_chan_I_A_INV_CUR_W_1_FUSI_idx,  /* 43U */
        Hwcal_chan_PORT5_CHAN4_idx,           /* 44U */
        Hwcal_chan_I_A_BRD_TEMP2_idx,         /* 45U */
        Hwcal_chan_I_A_CTRL_VAR_IN_idx,       /* 46U */
        Hwcal_chan_PORT5_CHAN7_idx,           /* 47U */
        Hwcal_chan_PORT6_CHAN0_idx,           /* 48U */
        Hwcal_chan_I_A_TLF_5V_VREF_idx,       /* 49U */
        Hwcal_chan_I_A_INV_CUR_W_1_idx,       /* 50U */
        Hwcal_chan_I_A_INV_CUR_U_1_FUSI_idx,  /* 51U */
        Hwcal_chan_I_A_EM_STAT_TEMP1_idx,     /* 52U */
        Hwcal_chan_PORT6_CHAN5_idx,           /* 53U */
        Hwcal_chan_PORT6_CHAN6_idx,           /* 54U */
        Hwcal_chan_PORT6_CHAN7_idx,           /* 55U */
        Hwcal_chan_PORT7_CHAN0_idx,           /* 56U */
        Hwcal_chan_I_A_5V_UC_idx,             /* 57U */
        Hwcal_chan_I_A_INV_CUR_W_2_idx,       /* 58U */
        Hwcal_chan_I_A_INV_CUR_V_1_FUSI_idx,  /* 59U */
        Hwcal_chan_I_A_EM_STAT_TEMP2_idx,     /* 60U */
        Hwcal_chan_PORT7_CHAN5_idx,           /* 61U */
        Hwcal_chan_PORT7_CHAN6_idx,           /* 62U */
        Hwcal_chan_PORT7_CHAN7_idx,           /* 63U */
        Hwcal_chan_PORT8_CHAN0_idx,           /* 64U */
        Hwcal_chan_PORT8_CHAN1_idx,           /* 65U */
        Hwcal_chan_PORT8_CHAN2_idx,           /* 66U */
        Hwcal_chan_PORT8_CHAN3_idx,           /* 67U */
        Hwcal_chan_PORT8_CHAN4_idx,           /* 68U */
        Hwcal_chan_PORT8_CHAN5_idx,           /* 69U */
        Hwcal_chan_PORT8_CHAN6_idx,           /* 70U */
        Hwcal_chan_PORT8_CHAN7_idx,           /* 71U */
        Hwcal_chan_I_T_INV_VOLT_HSS_U_1_idx,  /* 72U */
        Hwcal_chan_I_T_INV_VOLT_LSS_U_1_idx,  /* 73U */
        Hwcal_chan_I_T_INV_VOLT_HSS_V_1_idx,  /* 74U */
        Hwcal_chan_I_T_INV_VOLT_LSS_V_1_idx,  /* 75U */
        Hwcal_chan_I_T_INV_VOLT_HSS_W_1_idx,  /* 76U */
        Hwcal_chan_I_T_INV_VOLT_LSS_W_1_idx,  /* 77U */
        Hwcal_chan_I_T_INV_VOLT_HSS_U_2_idx,  /* 78U */
        Hwcal_chan_I_T_INV_VOLT_LSS_U_2_idx,  /* 79U */
        Hwcal_chan_I_T_INV_VOLT_HSS_V_2_idx,  /* 80U */
        Hwcal_chan_I_T_INV_VOLT_LSS_V_2_idx,  /* 81U */
        Hwcal_chan_I_T_INV_VOLT_HSS_W_2_idx,  /* 82U */
        Hwcal_chan_I_T_INV_VOLT_LSS_W_2_idx,  /* 83U */
        HWCAL_CHAN_MAX_NO,
    }
}
