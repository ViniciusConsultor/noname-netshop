<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DIY.aspx.cs" MasterPageFile="~/Site.Master" Inherits="NoName.NetShop.ForeFlat.Solution.DIY" %>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="head">
    <link type="text/css" rel="stylesheet" href="/css/solution.css" />
    <script type="text/javascript" src="/js/solution.diy.js"></script>
</asp:Content>

<asp:Content runat="server" ID="Content2" ContentPlaceHolderID="cpMain">    
    <!--Position Begin-->
    <div class="currentPosition">
    	您现在的位置: <a href="#">首页</a> &gt;&gt; <a href="#">影音解决方案</a> &gt;&gt; <a href="#">经典套装</a> &gt;&gt; <a href="#">私人影院</a> &gt;&gt; <a href="#">入门家庭影院</a> &gt;&gt; <a href="#">配置</a>
        <div class="solutionSubNav">
            <div class="solutionButtonTab">
                <a class="button_blue" href="#">按需制定</a>
                <a class="button_blue" href="#">推荐套装</a>
                <a class="button_blue2" href="#">经典套装</a>
            </div>
        </div>
    </div>
    <!--Position End-->
    
    <!--MainBody Begin-->
    <div class="solutionCustomize_mainbody clearfix newline">
    	<div class="leftColumn">
        	<span class="columnTitle">套装配置单</span>
            <div class="table1">
                <table>
                  <tr>
                    <th><span>配置</span></th>
                    <th><span>名称</span></th>
                    <th><span>数量</span></th>
                    <th><span>价格</span></th>
                    <th><span>删除</span></th>
                  </tr>
                  <tr class="odd">
                    <td>投影机</td>
                    <td>测试商品1111</td>
                    <td>1</td>
                    <td>90.00</td>
                    <td><a class="iconButton delete" href="#"></a></td>
                  </tr>
                  <tr class="even">
                    <td>音响</td>
                    <td>测试商品1111</td>
                    <td>1</td>
                    <td>90.00</td>
                    <td><a class="iconButton delete" href="#"></a></td>
                  </tr>
                  <tr class="odd">
                    <td>银幕</td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                  </tr>
                  <tr class="even">
                    <td>功放</td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                  </tr>
                  <tr class="odd">
                    <td>高清DVD</td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                  </tr>
                  <tr class="even">
                    <td>电视机顶盒</td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                  </tr>
                  <tr class="odd">
                    <td>游戏机</td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                  </tr>
                  <tr class="even">
                    <td>HDMI线</td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                  </tr>
                  <tr class="odd">
                    <td>视频线</td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                  </tr>
                  <tr class="even">
                    <td>音频线</td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                  </tr>
                  <tr class="odd">
                    <td>电源线</td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                  </tr>
                  <tr class="even">
                    <td>投影机吊架</td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                  </tr>
                  <tr class="odd">
                    <td>其他配件库</td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                  </tr>
                  <tr class="even">
                    <td>安装服务</td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                  </tr>
                  <tr class="bottom">
                    <td colspan="5">总计：￥17695.00</td>
                  </tr>
                </table>
            </div>
            <div class="buttons">
            	<a class="button_blue3" href="#">
                    <span class="left"></span>
                    <span class="text">清空配置单</span>
                    <span class="right"></span>
                </a>
                <a class="button_blue3" href="#">
                    <span class="left"></span>
                    <span class="text">提交订单</span>
                    <span class="right"></span>
                </a>
                <a class="button_blue3" href="#">
                    <span class="left"></span>
                    <span class="text">保存配置单</span>
                    <span class="right"></span>
                </a>
            </div>
    	</div>
        
        <div class="rightColumn">
        	<span class="columnTitle">设备列表</span>
            <div class="equipmentCategory">
            	<a href="#">投影机</a>
                <a href="#">音响</a>
                <a href="#">银幕</a>
                <a href="#">功放</a>
                <a href="#">高清DVD</a>
                <a href="#">游戏机</a>
                <a href="#">HDMI线</a>
                <a href="#">视频线</a>
                <a href="#">音频线</a>
                <a href="#">电源线</a>
                <a class="on" href="#">投影机吊架</a>
                <a href="#">其他配件库</a>
                <a href="#">电视机顶盒</a>
                <a href="#">安装服务</a>
            </div>
            <ul class="form">
            	<li>
                	<span class="field">投影机吊架</span>
                    <div class="component">
                    	<script type="text/javascript">
							var brandBox=new RainySelectBox();
							brandBox.boxName="brand";
							brandBox.fire="click";
							brandBox.name="brand";
							brandBox.id="brand";
							brandBox.width=120;
							brandBox.listMaxHeight=300;
							brandBox.selectedClass="commonSelectBox_currentOption";
							brandBox.listClass="commonSelectBox_list";
							brandBox.addOption("品牌","0","Selected");
							brandBox.addOption("西门子","1");
							brandBox.addOption("松下","2");
							brandBox.show();
						</script>
                    </div>
                    <input type="text" class="textField1" />
                    <div class="component">
                    	<a class="button_blue3" href="#">
                            <span class="left"></span>
                            <span class="text">搜索</span>
                            <span class="right"></span>
                        </a>
                    </div>
                </li>
            </ul>
            <div class="box6">
                <div class="title">
                	<span>商品列表</span>
                    <div class="sort">
                    	<a href="#" class="on">价格由高到低</a>
                        <a href="#">价格由低到高</a>
                    </div>
                </div>
                <div class="content noPaddingContentBox">
                    <div class="table2">
                        <table>
                          <tr>
                            <th class="first"><span>商品图片</span></th>
                            <th><span>商品名称</span></th>
                            <th><span>商品价格</span></th>
                            <th><span>选用</span></th>
                          </tr>
                          <tr class="odd">
                            <td><a href="#"><img src="pictures/productPic2.jpg" /></a></td>
                            <td><a href="#">安桥 CD 迷你音响组合 CS-325 兼容 CD/MP3/CD-R/CD-RW</a></td>
                            <td>￥6588</td>
                            <td><input type="checkbox" /></td>
                          </tr>
                          <tr class="even">
                            <td><a href="#"><img src="pictures/productPic2.jpg" /></a></td>
                            <td><a href="#">安桥 CD 迷你音响组合 CS-325 兼容 CD/MP3/CD-R/CD-RW</a></td>
                            <td>￥6588</td>
                            <td><input type="checkbox" /></td>
                          </tr>
                          <tr class="odd">
                            <td><a href="#"><img src="pictures/productPic2.jpg" /></a></td>
                            <td><a href="#">安桥 CD 迷你音响组合 CS-325 兼容 CD/MP3/CD-R/CD-RW</a></td>
                            <td>￥6588</td>
                            <td><input type="checkbox" /></td>
                          </tr>
                          <tr class="even">
                            <td><a href="#"><img src="pictures/productPic2.jpg" /></a></td>
                            <td><a href="#">安桥 CD 迷你音响组合 CS-325 兼容 CD/MP3/CD-R/CD-RW</a></td>
                            <td>￥6588</td>
                            <td><input type="checkbox" /></td>
                          </tr>                                  
                          <tr class="bottom">
                            <td colspan="4">
                              <div class="pagination">
                                <a class="prev" href="#"></a>
                                <div class="pageNum">
                                  <a class="on" href="#">1</a>
                                  <a href="#">2</a>
                                  <a href="#">3</a>
                                  <a href="#">4</a>
                                  <a href="#">5</a>
                                  <a href="#">6</a>
                                  <a href="#">7</a>
                                  </div>
                                <a class="next" href="#"></a>
                                <div class="jumpTo">
                                  <span>跳转到</span><input type="text" value="1" /><span>页</span>
                                  </div>
                                </div>
                            </td>
                          </tr>
                        </table>
                    </div>
                </div>
            </div>
            <div class="buttons">
                <a class="linkButton" href="#">去看看推荐套装&gt;&gt;</a>
            </div>
        </div>
    </div>
    <!--MainBody End-->
</asp:Content>
