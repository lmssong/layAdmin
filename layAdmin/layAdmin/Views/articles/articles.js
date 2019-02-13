
//加载文章列表

layui.use('table', function () {
    var table = layui.table;
    table.render({
        elem: '#articleList'
        , url: '/Articles/GetArticlesInfos'
        , cellMinWidth: 80 //全局定义常规单元格的最小宽度，layui 2.2.1 新增
        , page: true //开启分页
        , toolbar: '#barDemo' //开启工具栏，此处显示默认图标，可以自定义模板，详见文档
        , cols: [[
            { field: 'KID', width: 80, title: 'ID', sort: true }
            , { field: 'Title', width: 200, title: '标题', sort: true }
            , { field: 'TitleDescription', width: 180, title: '描述' }
            , { field: 'Category', title: '分类', minWidth: 100 } //minWidth：局部定义当前单元格的最小宽度，layui 2.2.1 新增
            , { field: 'Content', title: '内容', width: '30%', sort: true }
            , { field: 'Author', title: '作者', sort: true }
            , { field: 'ImgUrl', title: '图片地址', sort: true }
            , { field: 'CreateDate', title: '创建时间', sort: true }
        ]]
    });
});

//文章新增按钮
function addArticles() {
    var edit = layer.open({
        type: 2,
        shade: false,
        area: ['1000px', '500px'],
        maxmin: true,
        content: '/Articles/edit',
        scrollbar: true
    });
    layer.full(edit);
}

function deleteArticles() {

}