<?xml version="1.0"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:frmwrk="Corel Framework Data">
  <xsl:output method="xml" encoding="UTF-8" indent="yes"/>
  <frmwrk:uiconfig>
    <frmwrk:applicationInfo userConfiguration="true" />
  </frmwrk:uiconfig>

  <xsl:template match="node()|@*">
    <xsl:copy>
      <xsl:apply-templates select="node()|@*"/>
    </xsl:copy>
  </xsl:template>

  <xsl:template match="uiConfig/items">
    <xsl:copy>
      <xsl:apply-templates select="node()|@*"/>
      <itemData guid="37b10b4d-fba2-45d1-95f5-d6c54ecbc090" flyoutBarRef="89cbc9c5-f471-405b-a2b2-66de15c2f425" type="flyout" userCreated="true" noBmpOnMenu="true" userToolTip="CG Tools NET" userCaption="CG Tools NET"/>
      <itemData guid="9acd00df-b6e2-47ed-a3ce-8a2c31d5b696" dynamicCommand="CG_Tools.CGTools.Publish" dynamicCategory="2cc24a3e-fe24-4708-9a74-9c75406eebcd" userCaption="Save ke Non Permanent..." userToolTip="Save ke Non Permanent...">
        <userSmallBitmap xmlns:dt="urn:schemas-microsoft-com:datatypes" dt:dt="bin.base64">
          //8BABAAV0NtblVJX1VJSXRlbUJtcAAAAAAAAAAAKAAAAAAEAAAAAQAAKAAAABAAAAAQAAAA
          AQAIAAAAAAAAAQAAAAAAAAAAAAAAAQAAAAEAAAAAAAAAAAAAAAAAAAAAAAAZGRkAMzMzADMz
          MwBMTEwAZmZmAGZmZgB/f38AmZmZAJmZmQCysrIA8PDwAMzMzADMzMwA5eXlAP///wAAADMA
          AABmAAAAmQAzAGYAMzNmAAAAzAAzAJkAAAD/AGYAmQAzM5kAAAD/ADMAzABmAMwAMwD/ADMz
          zABmM5kAMwD/AGYA/wAzM/8AZmaZAGYzzABmAP8AmQDMAGYz/wCZAP8AmTPMAGZmzACZAP8A
          zAD/AJlmzACZM/8AzAD/AMwz/wCZmcwAADNmAAAzmQAAM8wAAGaZADNmmQAAM/8AADP/AABm
          zAAAZv8AAJnMADNmzAAAZv8AM5nMAACZ/wAAzP8AZpnMAAAzAAAAZgAAADMzAABmMwAAmQAA
          AGZmAACZMwAzZjMAAMwAADNmZgAA/wAAAJlmAAD/AAAzmTMAAMwzADOZZgAAzGYAM8wzAAD/
          MwAA/zMAAJmZADP/MwAzmZkAAMyZAGaZZgAA/2YAM8xmAAD/ZgAAzMwAAP+ZAGaZmQAzzJkA
          ZsxmAAD/mQAz/2YAM/+ZADPMzABmzJkAAP/MAAD/zABm/2YAM//MAGb/mQBmzMwAAP//AJnM
          mQCZzMwAmf+ZAGb/zACZ/8wAzP/MADMzAAAzZgAAM5kAAGZmAABmmQAAM8wAAGZmMwAz/wAA
          ZpkzAJmZAABmzAAAM/8AAGbMMwCZzAAAZv8AAGb/AACZmTMAzMwAAJn/AACZ/wAAmZlmAGb/
          MwCZzDMAmf8zAMz/AACZzGYAzP8AAMzMMwCZ/2YAzP8zAMzMZgD//wAA//8AAP//MwDM/2YA
          zMyZAMz/mQD//2YA//+ZAP//zABmAAAAOSAgADkmJgBmMwAAmQAAAJkzAADMAAAAZjMzAP8A
          AAD/AAAAzDMAAJlmAACZMzMAaVNTAG9YWAB1XV0AzDMzAP8zAADMZgAA/zMAAJlmMwCZZmYA
          zGYzAP8zMwD/ZgAAzJkAAP9mAACOc3IAkHVzAP9mMwDMZmYA/5kAAMyZMwD/mQAAnn9/AP/M
          AAD/ZmYA/8wAAMyZZgD/mTMA/5lmAP/MMwDMmZkA/5mZAP/MZgD/zJkA/8zMADMAMwA5JSgA
          OSYoADomKAA5JikAOiYpADonKQA7KCoAZgAzAEArLgBNOTsAZgBmAJkAMwBfTU8AzAAzAJkA
          ZgBmM2YAalZXAGtXWQD/ADMAmQCZAMwAZgCZM2YAel9hAP8AZgDMM2YAmTOZAMwAmQDMM5kA
          zDOZAJlmmQD/AJkAzADMAP8zZgCff4AAp4aIAP8AzADMZpkAzDPMALORkwDMZswA/2aZAP8z
          zAD/AP8A/wD/AMyZzAD/ZswA/zP/AP+ZzAAODg4ODg4ODg4ODg4ODg4ODg7Y2NjY2K3Y2NjY
          2NgODg4O2K6urtgR2NjYrq7YDg4ODtiurq7YEdjY2K6u2A4ODg7Yrq6t2BHY2NiurtgODg4O
          2K6urdjY2NjYrq7YDg4ODtiurq6urq6urq6u2A4ODg6u8fESEhISEhLx8a4ODg4OrvHxEhIS
          EhIS8UuuDg4ODq7x8RISEhISS/FLS0tKDg6u8fESEhISEktLS0tLDg4OrvG1EhISEktLS0tL
          S0sODq6urq6urq5LS0tLS0tLDg4ODg4ODg4ODktLS0tLDg4ODg4ODg4ODg5LS0tLS0oODg4O
          Dg4ODg4ODg5LDg4O8PDwAKCgoADw8PAAAAAAAA==
        </userSmallBitmap>
      </itemData>
    </xsl:copy>
  </xsl:template>

  <xsl:template match="uiConfig/commandBars">
    <xsl:copy>
      <xsl:apply-templates select="node()|@*"/>
      <commandBarData guid="89cbc9c5-f471-405b-a2b2-66de15c2f425" type="menu" nonLocalizableName="CG Tools NET" flyout="true">
        <menu>
          <item guidRef="9acd00df-b6e2-47ed-a3ce-8a2c31d5b696"/>
        </menu>
      </commandBarData>
    </xsl:copy>
  </xsl:template>

</xsl:stylesheet>