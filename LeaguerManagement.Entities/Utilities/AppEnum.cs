﻿using LeaguerManagement.Entities.Utilities.Extentsion;

namespace LeaguerManagement.Entities.Utilities
{
    public enum TokenType
    {
        AccessToken,
        ImageToken,
    }

    public enum AppDropdownDataType
    {
        Roles = 1,
        Units = 2,
        Statuses = 3,
    }

    public enum AppFileType
    {
        Copy = 1,
        Confirm = 2,
        Cartography = 3
    }

    public enum AppFileStatus
    {
        Handling = 1,
        Returning = 2,
        Finished = 3
    }

    public enum AppConfirmPurposeType
    {
        Transfer = 3,
        RentGdcm = 6,
        Buy = 7
    }

    public enum AppApplyFormality
    {
        [StringValue("Trực tiếp")]
        Direct = 1,
        [StringValue("Bưu điện")]
        Post = 2,
        [StringValue("Email")]
        Email = 3,
    }

    public enum AppChargeMethod
    {
        [StringValue("Tiền mặt")]
        Cash = 1,
        [StringValue("Chuyển khoản")]
        Transfer = 2,
    }
}