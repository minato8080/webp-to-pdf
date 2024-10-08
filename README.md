# webp-to-pdf 変換ツール

## 概要

複数のWebPファイルを一括でPDFファイルに変換するWindows用ツールです。

## 主な機能

- 複数のWebPファイルの選択
- 選択したWebPファイルのPDFへの一括変換
- 変換進捗の表示
- 変換後のPDFファイルの保存

## 動作環境

- Windows オペレーティングシステム
- .NET Core 8.0 ランタイム

## インストール方法

1. このリポジトリをクローンまたはダウンロードします。
2. プロジェクトフォルダで `dotnet build` を実行してアプリケーションをビルドします。

## 使用方法

1. アプリケーションを起動します。
2. 「WebPファイル選択」ボタンをクリックし、変換したいWebPファイルを選択します。
3. 選択したファイルが一覧に表示されます。
4. 「PDF変換実行」ボタンをクリックして変換を開始します。
5. 変換が完了したら、保存先を選択してPDFファイルを保存します。

## 技術スタック

- 言語: C#
- フレームワーク: .NET Core 8.0
- 主要ライブラリ:
  - ImageSharp: WebP画像の処理
  - PdfSharp: PDF生成

## ライセンス

このプロジェクトは [MITライセンス](LICENSE) の下で公開されています。