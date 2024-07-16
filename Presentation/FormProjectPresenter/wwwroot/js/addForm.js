function AddFields() {
    var x = $("#fields hr:first").attr("id");
    if (!x) {
        x = -1;
    }

    x++;
    var newFields = $(`    
        <div class="mt-2">
            <div class="input-group flex-nowrap"><input type="text" id="nameInput" name="FormFields [${x}].FieldName" class="form-control" placeholder="Alan Adi">
        </div>
        
        </div><div class="input-group mt-2"><select class="form-select" name="FormFields [${x}].DataType"><option selected>Veri Tipi Seciniz </option><option value="1">Sayisal</ option><option value="2">Metinsel</option></select>
        </div>
        
        <div class="form-check form-switch mt-3"><input name="FormFields[${x}].IsRequired" value="true"  class="form-check-input" type="checkbox" role="checkbox" id="IsRequired" checked><label class="form- check-label" for="IsRequired">Zorunlu Alan</label>
        </div>
        
        <hr id="${x}" />`
    );

    $('#fields').prepend(newFields);
}
