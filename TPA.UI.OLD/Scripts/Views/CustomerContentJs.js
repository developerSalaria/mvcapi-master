

var customerContent = {
    TransID: 0,

    init: function () {
        var GetLastRequestNumberURL = $('#GetLastRequestNumberURL').val();
        var GetDataURL = $('#GetDataURL').val();
        var GetPersonWithPersonCodeURL = $('#GetPersonWithPersonCodeURL').val();
        var GetEmployeeDataByCardNoURL = $('#GetEmployeeDataByCardNoURL').val();
        var DetailsURL = $('#DetailsURL').val();
        var SaveRL = $('#SaveRL').val();
        this._GetDate(DetailsURL,GetDataURL, GetPersonWithPersonCodeURL, GetEmployeeDataByCardNoURL, GetLastRequestNumberURL);
       // this._handleevents(DetailsURL, GetDataURL, GetPersonWithPersonCodeURL, GetEmployeeDataByCardNoURL, GetLastRequestNumberURL, SaveRL);
    },
    _GetDate: function (DetailsURL, GetDataURL, GetPersonWithPersonCodeURL, GetEmployeeDataByCardNoURL, GetLastRequestNumberURL) {
        that = this;
        $('#btnAdd').click(function () {
            Common.Ajax('GET', DetailsURL, {}, 'html', that.onID);
            
          
        });
    },
    onID: function (response) {
        debugger;
        //var that = this;
        this.TransID = response;
        $('#RequestDetaıls').html(response);

      //  customerContent._GetPersonCompanyData();

    },
    _handleNawakes: function () {
        var that = this;
        var GetNawakasForm = $('#GetNawakasForm').val();
        //$('#TransactionNawakas').click(function () {
            var urlNawakas = GetNawakasForm;
            var filterParams = {
                transactionNumber: $("#txttransNo").val()
            };
            Common.Ajax('GET', urlNawakas, filterParams, 'text', that.onGeTNawakasForm);
       // });

    },
    _New: function () {
        $('#btnAdd').click();
    },
    _attachment: function () {
      //  $('#ProTransactionAttachments').click(function () {
        var getAttachmentByCodeUrl = $("#GetAttachments").val();
            var model = {
                transactionNumber: $('#txttransNo').val()
            }
            Common.Ajax('POST', getAttachmentByCodeUrl, model, "text", this.onGetProTransactionAttachments);
        //});
    },
    onGetProTransactionAttachments: function (response) {
        try {
            var responseModel = JSON.parse(response);
            if (responseModel.status == 500) {



                swal.fire("Error!", responseModel.message, "error");
                $('#addNawakasModal').modal('hide');
                //renderdataTable();
            }
        } catch (error) {
            $('#attachmentsProBody').html(response);
            $('#attachmentsProModal').modal('show');
        }
        //else {
            
        //}
    },
    _Reload: function () {
        location.reload();
    }
    ,
     onGeTNawakasForm:function(response) {
        $('#addNawakasBody').html(response);

        $('#addNawakasModal').modal('show');
    }
    ,
    _saveNawakes: function () {
        var that =this;
            //save edit here
            var form = $('#AddNawakasfrm');
            //form.validate({
            //    rules: {
            //        nawakas: {
            //            required: true
            //        }
            //    }
            //});

            //if (!form.valid()) {
            //    console.log("Invalid");
            //    return;
            //}
            Common.Ajax('POST', form.attr('action'), form.serialize(), 'text', OnEditUserComplete);

            function OnEditUserComplete(response) {
                var responseModel = JSON.parse(response);

                if (responseModel.status == 200) {
                   

                    $('#addNawakasModal').modal('hide');
                    swal.fire("Good job!", responseModel.message, "success").then(function() {
                                  location.reload();      });
                    
                    //renderdataTable();

                }

                if (responseModel.status == 500) {
                    

                    swal.fire("Error!", responseModel.message, "error");
                    $('#addNawakasModal').modal('hide');
                    //renderdataTable();
                }
            }
        
    },
    _GetPersonCompanyData: function () {
        //GetComapnyDetailsurl
        var param = {
            companyCode:  $("#txtCompanyNo").val()
        }
        var GetComapnyDetailsurl = $('#GetComapnyDetailsurl').val();
        Common.Ajax('GET', GetComapnyDetailsurl, param, 'html', this._setcompanydetails);

    },
    _setcompanydetails: function (response) {
        var comp = response;
    },
    _save: function () {
        
        var SaveRL = $('#SaveRL').val();
        var that = this;
      //  $('#TransactionSave').click(function () {
            debugger;
            var filterParams = {
                itemNo: $("#txttransNo").val(),
                Reason: $("#txtReason").val() ,
                company: $("#txtCompanyNo").val()
            }
            Common.Ajax('POST', SaveRL, filterParams, 'text',that.reload);

        //});

    },
    _reject: function () {

        var SaveRL = $('#RejectRequesturl').val();
        var that = this;
        debugger;
        var filterParams = {
            itemNo: $("#txttransNo").val(),
            Reason: $("#txtReason").val()
        }
        Common.Ajax('POST', SaveRL, filterParams, 'text', that.reload);
    },
    reload: function (response) {

        var responseModel = JSON.parse(response);
        if (responseModel.status == 200) {
            swal.fire("Good job!", responseModel.message, "success").then(function() {
 location.reload();
});
           
        }
        if (responseModel.status == 500) {
            swal.fire("Error!", responseModel.message, "error");
        }

    }
}