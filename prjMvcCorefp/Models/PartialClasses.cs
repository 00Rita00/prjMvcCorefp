using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace prjMvcCorefp.Models
{
    [ModelMetadataType(typeof(TNursingRecordMetadata))]
    public partial class TNursingRecord
    {
    }

    [ModelMetadataType(typeof(TOffServiceMetadata))]
    public partial class TOffService
    {
    }

    [ModelMetadataType(typeof(TPatientInfoMetadata))]
    public partial class TPatientInfo
    {
    }
}