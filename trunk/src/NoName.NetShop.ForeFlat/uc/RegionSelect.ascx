<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RegionSelect.ascx.cs" Inherits="NoName.NetShop.ForeFlat.UC.RegionSelect" %>
<script type="text/javascript">
    
    var regionInfo = [{ "name": "province", "title": "请选择省/直辖市", "required": "true" },
    { "name": "city", "title": "请选择城市", "required": "true" },
    { "name": "county", "title": "请选择区县", "required": "false"}];
    var topregion = { "name": "country", "topid": "1803" }


    function regionValideSelect() {
        var result = true;
        $("#region").find("select").each(function() {
            if ($(this).css('display')!='none'&&$(this).attr("required") == "true" && ($(this).val() == null || $(this).val() == "")) {
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
            regionId = topregion.topid;
        }
        else {
            var curRegion = $("#region" + curIndex)
            if ($(curRegion).val() == null)
                return;
            regionId = $(curRegion).val();
        }

        var nextIndex = curIndex + 1;
        var nextRegion = $("#region" + nextIndex);

        $.ajax({
            type: "POST",
            url: "<%=ResolveClientUrl("~/api/CartOpenApi.ashx") %>",
            data: "action=getregion&regionid=" + regionId,
            dataType: "json",
            success: function(data) {
                if (data.length == 0) {
                    nextRegion.hide();
                    return;
                }
                else {
                    nextRegion.show();
                }
                if (regionInfo[nextIndex].text != "") {
                    // 显示提示信息
                    nextRegion.append("<option value=''>" + regionInfo[nextIndex].title + "</option>");
                }
                $.each(data, function(index, entry) {
                    nextRegion.append("<option value='" + entry["id"] + "'>" + entry["name"] + "</option>");
                });
                if (typeof (preset) == "undefined" || preset == null) return;
                if (preset && preset.length >= nextIndex) {
                    nextRegion.find("option[value='" + preset[nextIndex+1] + "']").attr("selected", "selected");
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
        for (var i = 0; i < regionInfo.length; i++) {
            regobj = null;
            if (i < regionInfo.length - 1)
                regobj = $('<select onchange="showNextRegion(' + i + ')"></select>');
            else
                regobj = $('<select></select>');
            regobj.attr("name", regionInfo[i].name);
            regobj.attr("id", "region" + i);
            regobj.attr("required", regionInfo[i].required);
            if (i>0) regobj.css("margin-left", "10px");
            $("#region").append(regobj);
        }
        $("#region").find("select").hide();
        showNextRegion();
    }
    
    function getRegionId(){
        var result = 0;
        $city = $("#region").find("select[name='city']");
        $province =  $("#region").find("select[name='province']");
        $county =  $("#region").find("select[name='county']");
        
        if ($county.val() != null && $county.val() != "")
        {
            result = $county.val();
        }
        else if ($city.val() != null && $city.val() != ""){
             result = $city.val();
        }
        else if ($province.val() != null && $province.val() != "")
        {
        result = $province.val();
        }
        return result;
    }
    
</script>
<span id="region">
</span>
<span id="regionerr" style="color:Red; display:none;">请选择地区</span>