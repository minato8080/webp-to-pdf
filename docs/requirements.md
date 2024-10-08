# 要件定義

## 目的
複数のwebpファイルを一括でPDFに変換する。

## 機能要件
- ユーザーがwebpファイルを選択できるファイル選択ダイアログ。
- 選択したファイルの並び順を変更する機能。
- 選択したwebpファイルをPDFに変換するボタン。
- 選択したファイルをクリアするボタン。
- 変換後のPDFファイルを指定のフォルダに保存する機能。
- pdfのファイルサイズを"画像に合わせる"、"A4縦向き"、"A4横向き"から選択するラジオボタン。

## 非機能要件
- Windows環境で動作すること。
- シンプルで直感的なユーザーインターフェース。

## 技術要件
- 使用するプログラミング言語：C#。
- フレームワーク：.NET Core 8.0。
- 画像処理ライブラリ（例：ImageSharp）とPDF生成ライブラリ（例：PdfSharp）。
