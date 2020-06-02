var dto;
var defaultImg;

function dupPersonDTO()
{
    this.IsArabicLanguage = false;
    this.IsEnglishLanguage = true;  // radio button is checked by default
    this.ChkNatLock = false;
    this.LblCurrrentStage = "";
    this.LblTransaction = "";
    this.ItemNumber = "";
    this.IsItemNumberLocked = false;
    this.PersonCode = "";
    this.IsPersonCodeLocked = false;
    this.NationalityCode = "";
    this.PassportNumber = "";
    this.DateOfBirth = "";
    this.NationalityDesc = "";
    this.BirthPlaceArb = "";
    this.PersonNameArb = "";
    this.PersonNameEng = "";
    this.Gender = "";
    this.ChkPerNameArb = false;
    this.ChkPerNameEng = false;
    this.LabelSets;
    this.DbEdit;
    this.ChkPersonName = false;
    this.ChkNationalityAndPersonName = false;
    this.ChkYOBAndPersonName = false;
    this.ChkPassportNo = false;
    this.ChkNationalityAndPassportNo = false;
    this.ChkNationalityAndYOBAndPassport = false;
    this.ChkSuper = false;
    this.ChkSuperEnabled = false;
    this.IsApprovalButtonEnabled = false;
    this.IsAddButtonEnabled = false;
    this.IsRejectButtonEnabled = false;
    this.RsData;
    this.RsList;
    this.Stage = 0;
    this.DocType = 0;
    this.MasterPerCode = "";
    this.SelCodes = "";
    this.PerCodes = "";
    this.IsAuto = false;
    this.Super = false;
    this.Central = false;
    this.IsCompanyTransaction = false;
    this.UserLo = "";
    this.UserId = "";
    this.MsgBoxResponse = false;
    this.Image = "";
    this.GetDuplicateValue = false;
    this.PrintDobLessThanCurrentDobMsgBoxResponse = false;

    this.IsPicBanVisible = false;
    this.PicBanToolTipText = "";
    this.IsPicAbsVisible = false;
    this.IsTimerEnabled = false;
    this.LtlPerImage = "";
    this.LtlPerGender = "";
}
function setDTO()
{
    dto.IsArabicLanguage = $('#IsArabicLanguage').is(':checked');
    dto.IsEnglishLanguage = $('#IsEnglishLanguage').is(':checked');
    dto.ChkNatLock = $('#ChkNatLock').is(':checked');
    dto.LblCurrrentStage = $('#LblCurrrentStage').text();
    //dto.LblTransaction = "";
    dto.ItemNumber = $('#ItemNumber').val();
    //dto.IsItemNumberLocked = false;
    //dto.PersonCode = "";
    //dto.IsPersonCodeLocked = false;
    dto.NationalityCode = $('#NationalityCode').val();;
    dto.PassportNumber = $('#PassportNumber').val();
    dto.DateOfBirth = $('#DateOfBirth').val();
    dto.NationalityDesc = $('#NationalityDesc').val();
    dto.BirthPlaceArb = $('#BirthPlaceArb').val();
    dto.PersonNameArb = $('#PersonNameArb').val();
    dto.PersonNameEng = $('#PersonNameEng').val();
    dto.Gender = $('#Gender').val();
    dto.ChkPerNameArb = $('#ChkPerNameArb').is(':checked');
    dto.ChkPerNameEng = $('#ChkPerNameEng').is(':checked');
    //dto.LabelSets = [];
    //dto.DbEdit = [];
    dto.ChkPersonName = $('#ChkPersonName').is(':checked');
    dto.ChkNationalityAndPersonName = $('#ChkNationalityAndPersonName').is(':checked');
    dto.ChkYOBAndPersonName = $('#ChkNationalityAndPersonName').is(':checked');
    dto.ChkPassportNo = $('#ChkPassportNo').is(':checked');
    dto.ChkNationalityAndPassportNo = $('#ChkNationalityAndPassportNo').is(':checked');
    dto.ChkNationalityAndYOBAndPassport = $('#ChkNationalityAndYOBAndPassport').is(':checked');
    dto.ChkSuper = $('#ChkSuper').is(':checked');
    //dto.ChkSuperEnabled = false;
    //dto.IsApprovalButtonEnabled = false;
    //dto.IsAddButtonEnabled = false;
    //dto.IsRejectButtonEnabled = false;
    //dto.RsData = [];
    //dto.RsList = [];
    //dto.Stage = "";
    //dto.DocType = "";
    //dto.MasterPerCode = "";
    //dto.SelCodes = "";
    //dto.PerCodes = "";
    //dto.IsAuto = false;
    //dto.Super = "";
    //dto.Central = "";
    //dto.IsCompanyTransaction = false;
    //dto.UserLo = "";
    //dto.UserId = "";
    //dto.MsgBoxResponse = false;
}
function getDTO()
{
    $('#IsArabicLanguage').prop('checked', dto.IsArabicLanguage);
    $('#IsEnglishLanguage').prop('checked', dto.IsEnglishLanguage);
    $('#ChkNatLock').prop('checked', dto.ChkNatLock);
    $('#LblCurrrentStage').html(dto.LblCurrrentStage);
    $('#ItemNumber').val(dto.ItemNumber);

    $("#ItemNumber")[0].disabled = dto.IsItemNumberLocked;
    //$("#PersonCode")[0].disabled = dto.IsPersonCodeLocked;

    $('#NationalityCode').val(dto.NationalityCode);
    $('#PassportNumber').val(dto.PassportNumber);
    $('#DateOfBirth').val(dto.DateOfBirth);
    $('#NationalityDesc').val(dto.NationalityDesc);
    $('#BirthPlaceArb').val(dto.BirthPlaceArb);
    $('#PersonNameArb').val(dto.PersonNameArb);
    $('#PersonNameEng').val(dto.PersonNameEng);
    $('#Gender').val(dto.Gender);
    if (dto.Image) {
        $('#Image').prop('src', dto.Image);
    } else {
        $('#Image').prop('src', defaultImg);
    }
    $('#ChkPerNameArb').prop('checked', dto.ChkPerNameArb);
    $('#ChkPerNameEng').prop('checked', dto.ChkPerNameEng);
    $('#ChkPersonName').prop('checked', dto.ChkPersonName);
    $('#ChkNationalityAndPersonName').prop('checked', dto.ChkNationalityAndPersonName);
    $('#ChkYOBAndPersonName').prop('checked', dto.ChkYOBAndPersonName);
    $('#ChkPassportNo').prop('checked', dto.ChkPassportNo);
    $('#ChkNationalityAndPassportNo').prop('checked', dto.ChkNationalityAndPassportNo);
    $('#ChkNationalityAndYOBAndPassport').prop('checked', dto.ChkNationalityAndYOBAndPassport);
    $('#ChkSuper').prop('checked', dto.ChkSuper);

    $('#IsPicBanVisible').attr('title', dto.PicBanToolTipText);
    if (dto.LtlPerImage) {
        $('#LtlPerImage').prop('src', dto.LtlPerImage);
    } else {
        $('#LtlPerImage').prop('src', defaultImg);
    }
    $('#LtlPerGender').html(dto.LtlPerGender);

    if (dto.IsPicAbsVisible) {
        $('#IsPicAbsVisible').removeClass('d-none')
    } else {
        $('#IsPicAbsVisible').addClass('d-none')
    }

    if (dto.IsPicBanVisible) {
        $('#IsPicBanVisible').removeClass('d-none')
    } else {
        $('#IsPicBanVisible').addClass('d-none');
    }

    $("#IsTimerEnabled")[0].disabled = !dto.IsTimerEnabled;


    var labels = '';
    //$('#LabelSets').html('');
    $('#personCards').contents(':not(#textSetCard)').remove();
    if (dto.LabelSets) {
        $.each(dto.LabelSets, function (key, value)
        {
            if (value) {
                /*labels += `<hr/><div class="row">
                <div class="col-6">
                    <div class="row mb-2">
                        <div class="col-6">
                            ${$('#hdnPassportNo').val()}
                            <input type="text" name="PerPassportNumber" class="form-control" readonly="readonly" value="${value.PerPassportNumber}" />
                        </div>
                        <div class="col-6">
                            ${$('#hdnGender').val()}
                            <input type="text" name="PerPassportNumber" class="form-control" readonly="readonly" value="${value.PerGender}" />
                        </div>
                    </div>
                    <div class="row  mb-2">
                        <div class="col-6">
                            ${ $("#hdnBirth").val()}
                            <input type="text" name="PerPassportNumber" class="form-control" readonly="readonly" value="${value.PerDateOfBirth}" />
                        </div>
                        <div class="col-6">
                            ${ $('#hdnBirthPlace').val()}
                           <input type="text" name="PerPassportNumber" class="form-control" readonly="readonly" value="${value.PerBirthCityArb}" />
                        </div>
                    </div>
                    <div class="row  mb-2">                
                        <div class="col-8">
                            ${ $('#hdnNationality').val()} 
                            <input type="text" name="PerPassportNumber" class="form-control" readonly="readonly" value="${value.PerNationalityDesc}" />
                        </div>
                    </div>
                </div>
                <div class="col-3">`
                if (value.PerImage) {
                    labels += '<img src="' + value.PerImage + '" onclick="showAcquire(this)" height="150" width="125" alt="صورة غير موجودة" />';
                } else {
                    labels += '<img src="' + defaultImg + '" height="150" onclick="showAcquire(this)"  width="125" alt="صورة غير موجودة" />';
                }
                labels += `</div>
                </div>
                <div class="row mb-2">       
                    <div class="col-8">
                        <i class="fas fa-ban ${ (!value.IsPicBanVisible) ? 'd-none' : ''}" title="${value.PicBanToolTipText}" ></i>
                        <input type="text" name="PerPassportNumber" class="form-control" readonly="readonly" value="${value.PerNameArb}" />
                    </div>
                </div>
                <div class="row">        
                    <div class="col-8">
                        <i class="fas fa-running ${ (!value.IsPicAbsVisible) ? 'd-none' : ''}" ></i>
                        <input type="text" name="PerPassportNumber" class="form-control" readonly="readonly" value="${value.PerNameEng}" />
                    </div>
                </div>`;*/

                labels += `<div class="col-4 border border-dark rounded-lg p-2">
                    <table>
                        <tr>
                            <td width="23%"></td>
                            <td width="35%"></td>
                            <td width="32%"></td>
                        </tr>
                        <tr>
                            <td>${$('#hdnPassportNo').val()}</td>
                            <td><input type="text" name="PerPassportNumber" class="form-control form-control-sm" readonly="readonly" value="${value.PerPassportNumber}" /></td>
                            <td class="text-right align-top" rowspan="4">`;
                if (value.PerImage) {
                                labels += '<img src="' + value.PerImage + '" onclick="showAcquire(this)" height="120" width="110" alt="صورة غير موجودة" />';
                }
                else {
                                labels += '<img src="~/images/199-1994175_png-file-svg-avatar-icon-png.png" height="120" onclick="showAcquire(this)"  width="110" alt="صورة غير موجودة" />';
                }
                labels +=   `</td>
                        </tr>
                        <tr>
                            <td>${$('#hdnGender').val()}</td>
                            <td><input type="text" name="PerGender" class="form-control form-control-sm" readonly="readonly" value="${value.PerGender}" /></td>
                        </tr>
                        <tr>
                            <td>${$("#hdnBirth").val()}</td>
                            <td><input type="text" name="PerDateOfBirth" class="form-control form-control-sm" readonly="readonly" value="${value.PerDateOfBirth}" /></td>
		                </tr>
                        <tr>
                            <td> ${$('#hdnBirthPlace').val()}</td>
                            <td><input type="text" name="PerBirthCityArb" class="form-control form-control-sm" readonly="readonly" value="${value.PerBirthCityArb}" /></td>
                        </tr>
                        <tr>
                            <td>${$('#hdnNationality').val()} </td>
                            <td><input type="text" name="PerNationalityDesc" class="form-control form-control-sm" readonly="readonly" value="${value.PerNationalityDesc}" /></td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <i class="fas fa-ban ${ (!value.IsPicBanVisible) ? 'd-none' : ''}" title="${value.PicBanToolTipText}" ></i>
                                <input type="text" name="PerPassportNumber" class="form-control form-control-sm" readonly="readonly" value="${value.PerNameArb}" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <i class="fas fa-running ${ (!value.IsPicAbsVisible) ? 'd-none' : ''}" ></i>
                                <input type="text" name="PerPassportNumber" class="form-control form-control-sm" readonly="readonly" value="${value.PerNameEng}" />
                            </td>
                        </tr>
	                </table>                    	
                </div>`;
            }
        });
        //$('#LabelSets').append(labels);        
        $('#personCards').append(labels);
    }

    let sets = '';
    $('#dbEdit').html('');
    if (dto.DbEdit) {
        sets += `<tr> 
                     <th>COM (#)</th>
                     <th>ESG (#)</th>
                     <th>LCD (#)</th>
                     <th>Passport</th>
                     <th>DOB</th>
                     <th>Nationality</th>
                     <th>Name Arb</th>
                     <th>Code</th>
                  </tr >`;
        $.each(dto.DbEdit, function (key, value)
        {
            if (value) {
                sets += `<tr> 
                           <td>${value[2]}</td>
                           <td>${value[3]}</td>
                           <td>${value[4]}</td>
                           <td>${value[5]}</td>
                           <td>${value[6]}</td>
                           <td>${value[7]}</td>
                           <td>${value[8]}</td>
                           <td><a onclick='showPersonStatus(this)' > ${value[9]}</a></td>
                        </tr>`;
            }
        });
        //sets += '</table>'

        $('#dbEdit').append(sets);
    }

    $("#ChkSuper")[0].disabled = !dto.ChkSuperEnabled;
    $("#btnApprove")[0].disabled = !dto.IsApprovalButtonEnabled;
    $("#btnAdd")[0].disabled = !dto.IsAddButtonEnabled;
    $("#btnReject")[0].disabled = !dto.IsRejectButtonEnabled;

}
function dupPersonCmd(index)
{
    //0,1,2,3,4,5,8, 12,16,18
    //if (validateAction(index)) 
    {
        //var urlmethod = '@Url.Action("DupPersonCommand")';
        var urlmethod = 'http://localhost/TPA.UI/DupPerson/DupPersonCommand'; //TODO: Wrong url !!
        setDTO();
        var params = {
            index: index,
            dupPersonDto: dto
        }
        Common.Ajax('post', urlmethod, params, 'text', checkDtoAndAssign);
    }
}
function checkDtoAndAssign(response)
{
    debugger;
    var res = JSON.parse(response);
    if (res.data && res.data.StatusCode == "200" && res.data.IsSuccessful) {
        if (res.data.Model) {
            dto = res.data.Model;
            getDTO();
            swal.fire("Success!", res.message, "success");
        }
        else {
            swal.fire("Error!", res.message, "error");
        }
    } else {
        if (res.message) {
            swal.fire("Error!", res.message, "error");
        }
    }

}
function validateAction(index)
{
    let msg = '';
    let validate = true;

    if (!$('#ItemNumber').val()) {
        swal.fire("error!", 'Please enter transaction number', "error");
        validate = false;
    }

    //0,1,2,3,4,5,12,16,18
    switch (index) {
        case 0: {
            //56
            if ($('#IsArabicLanguage').is(':checked')) {
                if (!$('#PersonNameArb').val()) {
                    swal.fire("error!", 'Please enter transaction number', "error");
                    validate = false;
                }
            } else {

                if (!$('#PersonNameEng').val()) {
                    swal.fire("error!", 'Please enter transaction number', "error");
                    validate = false;
                }
            }
            break;
        }
        case 1: {
            //arb60

            if ($('#IsArabicLanguage').is(':checked')) {
                if (!$('#PersonNameArb').val()) {
                    swal.fire("error!", 'Please enter transaction number', "error");
                    validate = false;
                }
            } else {
                if (!$('#PersonNameEng').val()) {
                    swal.fire("error!", 'Please enter transaction number', "error");
                    validate = false;
                }
            }
            if (!$('#NationalityCode').val()) {
                swal.fire("error!", 'Please enter transaction number', "error");
                validate = false;
            }
            break;
        }
        case 2: {
            //256
            if (!$('#DateOfBirth').val()) {
                swal.fire("error!", 'Please enter transaction number', "error");
                validate = false;
            }
            if ($('#IsArabicLanguage').is(':checked')) {
                if (!$('#PersonNameArb').val()) {
                    swal.fire("error!", 'Please enter transaction number', "error");
                    validate = false;
                }
            } else {
                if (!$('#PersonNameEng').val()) {
                    swal.fire("error!", 'Please enter transaction number', "error");
                    validate = false;
                }
            }
            break;
        }
        case 3: {
            //1
            if (!$('#PassportNumber').val()) {
                swal.fire("error!", 'Please enter transaction number', "error");
                validate = false;
            }
            break;
        }
        case 4: {
            //01
            if (!$('#NationalityCode').val()) {
                swal.fire("error!", 'Please enter transaction number', "error");
                validate = false;
            }
            if (!$('#PassportNumber').val()) {
                swal.fire("error!", 'Please enter transaction number', "error");
                validate = false;
            }

            break;
        }
        case 5: {
            //02
            if (!$('#NationalityCode').val()) {
                swal.fire("error!", 'Please enter transaction number', "error");
                validate = false;
            }
            if (!$('#DateOfBirth').val()) {
                swal.fire("error!", 'Please enter transaction number', "error");
                validate = false;
            }
            break;
        }
        case 12: {
            if ($('#IsArabicLanguage').is(':checked')) {
                if (!$('#PersonNameArb').val()) {
                    swal.fire("error!", 'Please enter transaction number', "error");
                    validate = false;
                }
            } else {
                if (!$('#PersonNameEng').val()) {
                    swal.fire("error!", 'Please enter transaction number', "error");
                    validate = false;
                }
            }
            break;
        }
        case 16: {

            break;
        }
        case 18: {

            break;
        }
            return validate;
    }
}
function showAttStatus()
{
    var urlmethod = `TPA.UI/DupPerson/AttStat?LoCode=${dto.UserLo}&isCentral=${dto.Central}`;

    Common.Ajax('get', urlmethod, null, 'text', function (response)
    {
        if (response) {
            $('#divAttStat').html('');
            $('#divAttStat').html(response);

            var modelData = JSON.parse($('#list').val());
            for (var i = 0; i < 20; i++) {
                var lblId = "#lbl_" + i;
                if ($(lblId)) {
                    $(lblId).html(0);
                }
            }
            if (modelData != undefined && modelData != null) {
                $.each(modelData, function (index, element)
                {
                    var dynamicId = "";
                    if (element.USER_TYPE == 0) {
                        if (element.TRAN_TYPE == 7) {
                            dynamicId = "lbl_6";
                        } else {
                            dynamicId = "lbl_" + element.TRAN_TYPE;
                        }
                    }
                    if (element.USER_TYPE == 1) {
                        dynamicId = "lbl_" + (element.TRAN_TYPE + 10);
                    }
                    if ($("#" + dynamicId)) {
                        $("#" + dynamicId).html(element.INCOMPLETE);
                    }
                });

                $('#divAttStat').show();
                $('#modalAttStat').modal('show');
                //$('#modalAttStat').modal('show');

            }
        }
    });
}
function showAcquire(control)
{
    $('#modelAcquire').modal("show");
    let img = $(control).attr('src');
    if (img) {
        $('#imgAcquire').attr('src', img);
    } else {

        $('#imgAcquire').attr('src', defaultImg);
    }
}
function hideAcquire()
{
    $('#modelAcquire').modal("hide");
}
function showPersonStatus(control)
{
    let perCode = $(control).html();
    if (perCode) {
        var urlmethod = `TPA.UI/DupPerson/PerStat?perCode=${perCode}`;

        Common.Ajax('get', urlmethod, null, 'text', function (response)
        {
            if (response) {
                $('#divPersonStat').html('');
                $('#divPersonStat').html(response);
                $('#modalPersonStat').modal('show');
            }
        });
    }
}
function timerClick()
{
    let param = {
        perCode: '',
        strbanExpiry: '',
        perHasBalagh: '',
        perSexCode: ''
    };

    if (dto.RsList && dto.DbEdit) {

        let dbEditCode = dto.DbEdit[0][9];
        if (dbEditCode) {
            let rowIndex = 0;
            for (var i = 0; i < dto.RsList.length; i++) {
                if (dto.RsList[i].PER_CODE == dbEditCode) {
                    rowIndex = i;
                    break;
                }
            }

            if (rowIndex > -1) {

                param.perCode = dto.RsList[rowIndex].PER_CODE;
                param.strbanExpiry = dto.RsList[rowIndex].BAN_EXPIRY;
                param.perHasBalagh = dto.RsList[rowIndex].PER_HAS_BALAGH;
                param.perSexCode = dto.RsList[rowIndex].PER_SEX_CODE;

                let urlmethod = `TPA.UI/DupPerson/TimerClick?perCode=${param.perCode}&strbanExpiry=${param.strbanExpiry}&perHasBalagh=${param.perHasBalagh}&perSexCode=${param.perSexCode}`;

                Common.Ajax('get', urlmethod, null, 'text', function (response)
                {
                    var res = JSON.parse(response);
                    if (res.data && res.data.StatusCode == "200" && res.data.IsSuccessful && res.data.Model) {
                        let model = res.data.Model;
                        dto.IsTimerEnabled = model.IsTimerEnabled;
                        dto.LtlPerImage = model.LtlPerImage;
                        dto.IsPicBanVisible = model.IsPicBanVisible;
                        dto.PicBanToolTipText = model.PicBanToolTipText;
                        dto.IsPicAbsVisible = model.IsPicAbsVisible;
                        dto.LtlPerGender = model.LtlPerGender;
                        getDTO();

                    } else {
                        swal.fire("Error!", res.message, "error");
                    }
                });

            }
        }
    }
}
function showAttachments()
{
    var urlmethod = `TPA.UI/DupPerson/ShowAttachment?itemNo=${dto.ItemNumber}&docType=${dto.DocType}`;

    Common.Ajax('get', urlmethod, null, 'text', function (response)
    {
        if (response) {
            $('#divShowAttachmentBody').html('');
            $('#divShowAttachmentBody').html(response);
            $('#divShowAttachment').modal('show');
        }
    });
}