Imports System
Imports System.Text
Imports Microsoft.Web.Administration

Module Sample
   Sub Main()
      Dim serverManager As ServerManager = New ServerManager
      Dim config As Configuration = serverManager.GetApplicationHostConfiguration
      Dim sitesSection As ConfigurationSection = config.GetSection("system.applicationHost/sites")
      Dim siteDefaultsElement As ConfigurationElement = sitesSection.GetChildElement("siteDefaults")
      Dim ftpServerElement As ConfigurationElement = siteDefaultsElement.GetChildElement("ftpServer")

      Dim securityElement As ConfigurationElement = ftpServerElement.GetChildElement("security")
      Dim authenticationElement As ConfigurationElement = securityElement.GetChildElement("authentication")
      Dim anonymousAuthenticationElement As ConfigurationElement = authenticationElement.GetChildElement("anonymousAuthentication")
         anonymousAuthenticationElement("enabled") = False
      Dim basicAuthenticationElement As ConfigurationElement = authenticationElement.GetChildElement("basicAuthentication")
         basicAuthenticationElement("enabled") = True

      serverManager.CommitChanges()
   End Sub

End Module