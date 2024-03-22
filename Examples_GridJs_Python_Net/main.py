# This is a demo to show how to use GridJs .
import configparser
import io
import mimetypes
import os
from aspose.cellsgridjs import *
import requests
# from aspose.cells import Workbook, SaveFormat, CellsHelper


from flask import Flask, render_template, jsonify, request, send_from_directory, Response, send_file, abort

config = configparser.ConfigParser()
config.read('config.ini')
app=Flask(__name__)
# your working file directory which has spreadsheet files inside wb directory，
FILE_DIRECTORY = os.path.join(os.getcwd(),'wb')

@app.route('/')
def index():
    filename=config.get('DEFAULT', 'FileName')
    return render_template('uidload.html',filename= filename,uid=GridJsWorkbook.get_uid_for_file(filename))



# get json info from  /GridJs2/DetailJson?filename=
@app.route('/GridJs2/DetailJson', methods=['GET'])
def detail_file_json():
    filename = request.args.get('filename')
    if not filename:
        return jsonify({'error': 'filename is required'}), 400
    gwb = GridJsWorkbook()
    # 构造文件的完整路径
    file_path = os.path.join(FILE_DIRECTORY, filename)

    # 检查文件是否存在
    if not os.path.isfile(file_path):
        return jsonify({'error': 'file not found'}), 404
    try:
        gwb.import_excel_file(file_path)
        ret = gwb.export_to_json(filename)
        # 创建一个响应对象，传入响应体、状态码、头部信息等
        response = Response(ret, status=200, mimetype='text/plain')

        # 设置响应的字符编码为UTF-8
        response.headers['Content-Type'] = 'text/plain; charset=utf-8'

        # 返回响应对象
        return response

    except Exception as ex:
        return jsonify({'error': str(ex)}), 500




# get json info from : /GridJs2/DetailFileJsonWithUid?filename=&uid=
@app.route('/GridJs2/DetailFileJsonWithUid', methods=['GET'])
def detail_file_json_with_uid():
    filename = request.args.get('filename')
    uid = request.args.get('uid')
    if not filename:
        return jsonify({'error': 'filename is required'}), 400
    if not uid:
        return jsonify({'error': 'uid is required'}), 400
    gwb = GridJsWorkbook()
    file_path = os.path.join(FILE_DIRECTORY, filename)

    # 检查文件是否存在
    if not os.path.isfile(file_path):
        return jsonify({'error': 'file not found:'+file_path}), 404
    try:
        sb = gwb.get_json_str_by_uid(uid, filename)
        if sb == None:
            gwb.import_excel_file(uid, file_path)
            sb = gwb.export_to_json(filename)
        # 创建一个响应对象，传入响应体、状态码、头部信息等
        response = Response(sb, status=200, mimetype='text/plain')

        # 设置响应的字符编码为UTF-8
        response.headers['Content-Type'] = 'text/plain; charset=utf-8'

        # 返回响应对象
        return response

    except Exception as ex:
        return jsonify({'error': str(ex)}), 500

# update action :/GridJs2/UpdateCell
@app.route('/GridJs2/UpdateCell', methods=['POST'])
def update_cell():
    # 从请求中获取表单数据
    p = request.form.get('p')
    uid = request.form.get('uid')

    # 创建GridJsWorkbook实例
    gwb = GridJsWorkbook()

    # 调用UpdateCell方法并获取结果
    ret = gwb.update_cell(p, uid)

    # 返回一个JSON响应，因为Flask默认返回JSON
    # 如果你确实需要返回纯文本，你可以修改Content-Type并返回字符串
    return Response(ret, content_type='text/plain; charset=utf-8')

# add image :/GridJs2/AddImage
@app.route('/GridJs2/AddImage', methods=['POST'])
def add_image():
    uid = request.form.get('uid')
    p = request.form.get('p')
    iscontrol = request.form.get('control')
    gwb = GridJsWorkbook()
    # 检查是否有文件上传

    if iscontrol is None:
            if 'image' not in request.files:
            # 没有文件上传，检查iscontrol是否为空

                ret = gwb.insert_image(uid, p, None, None)
                return jsonify(ret)

            else:
                file = request.files['image']

                if file.filename == '':
                    # 文件名为空，返回错误
                    return jsonify(gwb.error_json("no file when add image"))
                else:
                    # 有文件上传
                    try:
                    # 调用InsertImage方法并返回结果
                        file_bytes = io.BytesIO(file.read())
                        print('file length  is:'+str(len(file_bytes.getvalue())))
                        ret = gwb.insert_image(uid, p, file_bytes, None)
                        return jsonify(ret)
                    except Exception as e:
                        # 发生异常，返回错误信息
                        return jsonify(gwb.error_json(str(e)))

    else:

        try:
            ret = gwb.insert_image(uid, p, None, None)
            return jsonify(ret)
        except Exception as e:
            # 发生异常，返回错误信息
            return jsonify(gwb.error_json(str(e)))

# copy image :/GridJs2/CopyImage
@app.route('/GridJs2/CopyImage', methods=['POST'])
def copy_image():
    uid = request.form.get('uid')
    p = request.form.get('p')
    gwb = GridJsWorkbook()
    ret = gwb.copy_image_or_shape(uid,p)
    return jsonify(ret)

def get_stream_from_url(url):
    response = requests.get(url)
    response.raise_for_status()  # 如果请求失败，这会抛出HTTPError
    return io.BytesIO(response.content)

# add image by image source url:/GridJs2/AddImageByURL
@app.route('/GridJs2/AddImageByURL', methods=['POST'])
def add_image_by_url():
    uid = request.form.get('uid')
    p = request.form.get('p')
    imageurl = request.form.get('imageurl')
    gwb = GridJsWorkbook()
    if imageurl is not None:
        try:
            stream = get_stream_from_url(imageurl)
            ret = gwb.insert_image(uid, p, stream, imageurl)
        except Exception as e:
            return jsonify(gwb.error_json(str(e)))

        return jsonify(ret)
    else:
        return jsonify(gwb.error_json('image url is null'))


#get image :/GridJs2/Image
@app.route('/GridJs2/Image', methods=['GET'])
def image():
    fileid = request.args.get('id')
    uid = request.args.get('uid')

    if fileid is None or uid is None:
        # 如果缺少参数，返回错误响应
        return 'Missing required parameters', 400
    else:
        # 获取图片流
        image_stream = GridJsWorkbook.get_image_stream(uid, fileid)

         # 设置响应的 MIME 类型和附件名（如果需要的话）
        mimetype = 'image/png'
        attachment_filename = fileid

        # 发送文件流作为响应
        return send_file(
            image_stream,
            as_attachment=False,  # 如果作为附件发送
            download_name=attachment_filename,  # 下载时的文件名
            mimetype=mimetype
        )


def guess_mime_type_from_filename(filename):
    # 猜测 MIME 类型
    mime_type, encoding = mimetypes.guess_type(filename)
    if mime_type is None:
        # 如果没有找到，返回默认的二进制 MIME 类型
        mime_type = 'application/octet-stream'
    return mime_type


# get ole file: /GridJs2/Ole?uid=&id=
@app.route('/GridJs2/Ole', methods=['GET'])
def ole():
    oleid = request.args.get('id')
    uid = request.args.get('uid')
    sheet = request.args.get('sheet')
    gwb = GridJsWorkbook()
    filename = None
    filebyte = gwb.get_ole(uid, sheet, oleid, filename)
    if filename != None:

        # 获取图片流
        ole_stream = io.BytesIO(filebyte)

    # 设置响应的 MIME 类型和附件名（如果需要的话）
        mimetype = guess_mime_type_from_filename(filename)


    # 发送文件流作为响应
        return send_file(
            ole_stream,
            as_attachment=True,  # 如果作为附件发送
            download_name=filename,  # 下载时的文件名
            mimetype=mimetype
        )
    else:
        # 如果没有获取到文件名，返回 404 错误
        abort(400, 'File not found')


#get batch zip image file url : /GridJs2/ImageUrl?uid=&id=
@app.route('/GridJs2/ImageUrl', methods=['GET'])
def image_url():
    id = request.args.get('id')
    uid = request.args.get('uid')
    file = uid + "." + id;
    return  jsonify("/GridJs2/GetZipFile?f="+ file)


#get zip file : /GridJs2/GetZipFile?f=
@app.route('/GridJs2/GetZipFile', methods=['GET'])
def get_zip_file():
    file = request.args.get('f')
    file_path = os.path.join(Config.file_cache_directory, file)
    # 检查文件是否存在
    if os.path.isfile(file_path):
        # 设置 MIME 类型为 application/zip
        mimetype = 'application/zip'

        # 使用 send_file 发送文件作为响应
        # as_attachment=True 表示作为附件发送，download_name 指定下载时的文件名
        return send_file(file_path, as_attachment=True, download_name=file, mimetype=mimetype)
    else:
        # 如果文件不存在，返回 404 错误
        abort(404, description='File not found')


#get file: /GridJs2/GetFile?uid=&id=
@app.route('/GridJs2/GetFile', methods=['GET'])
def get_file():
    id = request.args.get('id')
    filename = request.args.get('filename')
    if filename != None:
        mimetype=guess_mime_type_from_filename(filename)
        file_path = os.path.join(Config.file_cache_directory, id.replace('/', '.')+"."+filename)
        # 检查文件是否存在
        if os.path.isfile(file_path):
            # 设置 MIME 类型为 application/zip

            # 使用 send_file 发送文件作为响应
            # as_attachment=True 表示作为附件发送，download_name 指定下载时的文件名
            return send_file(file_path, as_attachment=True, download_name=filename, mimetype=mimetype)
    else:
        abort(404, description='FileName is none')

# download file :/GridJs2/Download
@app.route('/GridJs2/Download', methods=['POST'])
def download():
    p = request.form.get('p')
    uid = request.form.get('uid')
    filename = request.form.get('file')
    gwb = GridJsWorkbook()

    try:
        gwb.merge_excel_file_from_json(uid, p)

        gwb.save_to_cache_with_file_name(uid, filename, None);

    except Exception as e:
        return jsonify(gwb.error_json(str(e)))
    if (Config.save_html_as_zip and filename.endswith(".html")):
        filename += ".zip";
    fileurl = "/GridJs2/GetFile?id=" + uid + "&filename=" + filename;
    return jsonify(fileurl)


def do_at_start(name):

    print(f'Hi, {name}  {FILE_DIRECTORY}')


    # do some init work for GridJS
    # set storage cache directory for GridJs
    Config.set_file_cache_directory(config.get('DEFAULT', 'CacheDir'))
    # set License for GridJs
    Config.set_license(config.get('DEFAULT', 'LicenseFile'))
    # set Image route for GridJs,correspond with image()
    GridJsWorkbook.set_image_url_base("/GridJs2/Image");
    print(f'{Config.file_cache_directory}')



if __name__ == '__main__':
    do_at_start('hello gridjs')
    app.run(port=2022, host="127.0.0.1", debug=True)

