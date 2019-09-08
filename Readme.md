# LinkRedirect
[![GitHub issues](https://img.shields.io/github/issues/moderras/linkredirect?style=for-the-badge)](https://github.com/moderras/linkredirect/issues)
[![GitHub forks](https://img.shields.io/github/forks/moderras/linkredirect?style=for-the-badge)](https://github.com/moderras/linkredirect/network)
[![GitHub stars](https://img.shields.io/github/stars/moderras/linkredirect?style=for-the-badge)](https://github.com/moderras/linkredirect/stargazers)
[![GitHub license](https://img.shields.io/github/license/moderras/linkredirect?style=for-the-badge)](https://github.com/ModerRAS/LinkRedirect/blob/master/LICENSE)
[![Twitter](https://img.shields.io/twitter/url/https/github.com/moderras/linkredirect?style=social)](https://twitter.com/intent/tweet?text=Wow:&url=https%3A%2F%2Fgithub.com%2Fmoderras%2Flinkredirect)

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
