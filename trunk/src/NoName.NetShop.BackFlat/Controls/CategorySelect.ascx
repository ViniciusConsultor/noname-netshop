<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategorySelect.ascx.cs" Inherits="NoName.NetShop.BackFlat.Controls.CategorySelect" %>
<script type="text/javascript">
    
    var topregion = { "name": "category1", "topid": "0-all" }


    function regionValideSelect() {
        var result = true;
        $("#region").find("select").each(function() {
            if ($(this).attr("required") == "true" && ($(this).val() == null || $(this).val() == "")) {
                result = false;
                return result;
            }
        });
        if (result == false) {
            $("#regionerr").show();
        }
        else
            $("#regionerr").hide();
        return result;
    }

    function showNextRegion(curIndex) {
        //debugger;
        $("#regionerr").hide();
        if (curIndex == undefined) {
            curIndex = -1;
        }

        // 后边的级联需要被隐藏并清空
        $("#region").find("select").each(function(index) {
            if (index > curIndex) {
                $(this).empty();
                $(this).hide();
            }
            else {
                $(this).show();
            }
        });

        var regionId;
        if (curIndex == -1) {
            regionId = topregion.topid.split('-')[0];
        }
        else {
            var curRegion = $("#region" + curIndex)
            if ($(curRegion).val() == null || $(curRegion).val() == '') {
                $('#<%= selectedCategory.ClientID %>').val(curIndex == 0 ? 0 : $("#region" + (curIndex - 1)).val().split('-')[0]);
                return;
            }
            regionId = $(curRegion).val().split('-')[0];
        }

        $('#<%= selectedCategory.ClientID %>').val(regionId);

        var nextIndex = curIndex + 1;
        var nextRegion = $("#region" + nextIndex);

        $.ajax({
            type: "get",
            url: "/controls/categoryprovider.ashx?parentid="+regionId,
            dataType: "json",
            cache:false,
            success: function(data) {
                if (data.length == 0) {
                    nextRegion.hide();
                    return;
                }
                else {
                    nextRegion.show();
                }
                if (categoryInfo[nextIndex].title != "") {
                    // 显示提示信息
                    nextRegion.append("<option value=''>" + categoryInfo[nextIndex].title + "</option>");
                }
                $.each(data, function(index, entry) {
                    nextRegion.append("<option value='" + entry["cateid"] + "-" + entry["catename"] + "'>" + entry["catename"] + "</option>");
                });
                if (preset == null || preset == undefined) return;
                if (preset && preset.length >= nextIndex) {
                    nextRegion.find("option[value^='" + preset[nextIndex] + "-']").attr("selected", "selected");
                    if (nextRegion.val() != null) {
                        showNextRegion(nextIndex);
                    }
                }
            }
        });
    }

    function InitRegions() {
        
        var regiontop = $('<input type="hidden" id="' + topregion.name + '" name="' + topregion.name + '" value="' + topregion.topid + '" />');
        $("#region").append(regiontop);
        for (var i = 0; i < categoryInfo.length; i++) {
            regobj = null;
            if (i < categoryInfo.length - 1)
                regobj = $('<select onchange="showNextRegion(' + i + ')"></select>');
            else
                regobj = $('<select></select>');
            regobj.attr("name", categoryInfo[i].name);
            regobj.attr("id", "region" + i);
            regobj.attr("required", categoryInfo[i].required);
            if (i > 0) regobj.css("margin-left", "10px");
            $("#region").append(regobj);
        }
        $("#region").find("select").hide();
        showNextRegion();
    }

    
</script>
<span id="region">
</span>
<span id="regionerr" style="color:Red; display:none;">请选择地区</span>
<input id="selectedCategory" type="hidden" runat="server"/>