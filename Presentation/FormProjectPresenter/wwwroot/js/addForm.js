function AddFields() {
    var x = $("#fields hr:first").attr("id");
    if (!x) {
        x = -1;
    }

    x++;
    var newFields = $(`    
        <div class="mt-2">
            <div class="input-group flex-nowrap"><input type="text" required data-parsley-required-message="Bu alan bos gecilemez!" data-parsley-errors-container="#nameError${x}" id="nameInput" name="FormFields[${x}].FieldName" class="form-control" placeholder="Alan Adi">
        </div>
        <div class="mt-2" style="color:red;" id="nameError${x}">
        </div>
        
        </div><div class="input-group mt-2"><select data-parsley-errors-container="#dataTypeError${x}" data-parsley-required-message="Bu alan bos gecilemez!" class="form-select" required name="FormFields[${x}].DataType"><option selected value="">Veri Tipi Seciniz </option><option value="1">Sayisal</ option><option value="2">Metinsel</option></select>
        </div>
         <div class="mt-2" style="color:red;" id="dataTypeError${x}">
        </div>

        <div class="form-check form-switch mt-3"><input name="FormFields[${x}].IsRequired" value="true"  class="form-check-input" type="checkbox" role="checkbox" id="IsRequired" checked><label class="form- check-label" for="IsRequired">Zorunlu Alan</label>
        </div>
        
        <hr id="${x}" />`
    );

    $('#fields').prepend(newFields);
}
