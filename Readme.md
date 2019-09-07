# LinkRedirect
自动反代图片的小工具
## 使用Docker安装
```
docker pull moderras/linkredirect
```

## 在Docker中启动
```
docker run -d -e RedirectURL=i.example.com -p 5000:80 --restart=always -v /the/path/you/save/database:/app/Database --name LinkRedirect moderras/linkredirect
```

## 在Caddy中配置反代
```
link.example.com {
    tls 
    gzip
    timeouts none
    rewrite .* /link
    proxy / http://127.0.0.1:5000
}
i.example.com {
    tls 
    gzip
    cache
    timeouts none
    proxy / http://127.0.0.1:5000/image
}
```

## 使用
访问`https://link.example.com/?=https://some.pictures.com/pic.jpg`后将自动跳转到`https://i.example.com/24075eb4d44dd685ca7a4fa48a30f4848568a129a956dc3f779f4447c1c0f8ea.jpg`.