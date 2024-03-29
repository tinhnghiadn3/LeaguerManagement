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
        ChangeOfficialDocumentTypes = 4,
        ChangeOfficialDocuments = 5,
        Years = 5
    }

    public enum AppLeaguerStatus
    {
        Official = 1,
        Preliminary = 2,
        GetOut = 3,
        Dead = 4
    }

    public enum AppLeaguerRating
    {
        Best = 1,
        Well = 2,
        Done = 3,
        NotDone = 4,
        Temp = 5
    }
}
