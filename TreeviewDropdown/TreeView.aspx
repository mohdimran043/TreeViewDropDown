<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TreeView.aspx.cs" Inherits="TreeviewDropDown.TreeView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Treeview Local Data</title>
    <link href="http://cdn.kendostatic.com/2013.2.716/styles/kendo.common.min.css" rel="stylesheet" />
    <link href="http://cdn.kendostatic.com/2013.2.716/styles/kendo.default.min.css" rel="stylesheet" />
    <link href="http://cdn.kendostatic.com/2013.2.716/styles/kendo.dataviz.min.css" rel="stylesheet" />
    <link href="http://cdn.kendostatic.com/2013.2.716/styles/kendo.mobile.all.min.css" rel="stylesheet" />
    <script src="http://code.jquery.com/jquery-1.9.1.min.js"></script>
    <script src="http://cdn.kendostatic.com/2013.2.716/js/kendo.all.min.js"></script>
    <script id="treeview-template" type="text/kendo-ui-template">
            <itm class='actual-item' data-id='#: item.id #'>#: item.text #</itm>
            # if (!item.items) { #
                <a class='delete-link' href='\#'></a>
            # } #
    </script>

    <script type="text/javascript">
        function InitSearch(treeViewId, searchInputId, treeviewDropdownBtn) {
            var tv = $(treeViewId).data('kendoTreeView');

            $(searchInputId).on('keyup', function () {
                $(treeViewId + ' li.k-item').show();

                $('span.k-in > span.highlight').each(function () {
                    $(this).parent().text($(this).parent().text());
                });

                // ignore if no search term
                if ($.trim($(this).val()) === '') {
                    tv.select() //gets currently selected <li> element
                        .find("span.k-state-selected")
                            .removeClass("k-state-selected"); //removes the highlight class

                    $('#lblselected').html("Selecting: --");
                    return;
                }

                var term = this.value.toUpperCase();
                var tlen = term.length;

                $(treeViewId + ' span.k-in').each(function (index) {
                    var text = $(this).text();
                    var html = '';
                    var q = 0;
                    var p;

                    while ((p = text.toUpperCase().indexOf(term, q)) >= 0) {
                        html += text.substring(q, p) + '<span class="highlight">' + text.substr(p, tlen) + '</span>';
                        q = p + tlen;
                    }

                    if (q > 0) {
                        html += text.substring(q);
                        $(this).html(html);

                        $(this).parentsUntil('.k-treeview').filter('.k-item').each(function (index, element) {
                            tv.expand($(this));
                            $(this).data('SearchTerm', term);
                        });
                    }
                });

                $(treeViewId + ' li.k-item:not(:has(".highlight"))').hide();
            });


            $(searchInputId).on('blur', function () {
                if ($('#treeViewSearchInput').val() == '') {
                    //$('#treeview').hide();              
                } else {
                    $('#treeview').show();
                }
            });

            $(searchInputId).on('focus', function () {
                $('#treeview').show(); $('#treeViewSearchInput').keyup();
            });

            $(treeviewDropdownBtn).on('click', function () {
                $('#treeview').toggle();
            });


        }

        $(document).ready(function () {
            var $tv = $("#treeview").kendoTreeView({
                dataSource: {
                    data: [
                        { text: "Item 1" },
                        {
                            text: "Item 2", items: [
                              { text: "SubItem 2.1" },
                              { text: "SubItem 2.2" }
                            ]
                        },
                        { text: "Item 3" }
                    ]
                },
                select: onSelect,
                dragAndDrop: true
            }).data("kendoTreeView")

            InitSearch("#treeview", "#treeViewSearchInput", "#treeviewDropdownBtn");
        });

        function onSelect(e) {
            var item = this.dataItem(e.node);
            //alert("Selecting: " + this.text(e.node) + "ID:" + item.id);
            $('#lblselected').html("Selecting: " + this.text(e.node) + " & ID:" + item.id);
            $('#treeview').hide();
            $('#treeViewSearchInput').val(item.text);
            $('#treeview').hide();
        }

        function setTreeView() {
            if ($('#treeViewSearchInput').val() == '') {
                //$('#treeview').hide();              
            } else {
                $('#treeview').show();
            }
        }
    </script>
    <style type="text/css" scoped>
        span.k-in > span.highlight {
            background: #7EA700;
            color: #ffffff;
            border: 1px solid green;
            padding: 1px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>
                <label id="lblselected"></label>
            </p>
            <div id="container" style="float: left; min-width: 175px; background-color: rgb(198, 198, 198);">
                <span>
                    <input type="text" id="treeViewSearchInput" placeholder=" -- select --" /><input id="treeviewDropdownBtn" type="button" value="V" /></span>
                <div id="treeview" style="display: none;">
                </div>
            </div>
        </div>
    </form>
</body>
</html>
