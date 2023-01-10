<%@ WebService Language="VB" Class="TimeService"%>

Imports System
Imports System.Web.Services

Public Class TimeService: Inherits WebService
  Public function <WebMethod()> GetTime(ShowSeconds as boolean) as string
    dim dt as DateTime
    if ShowSeconds then
      GetTime = dt.Now.ToLongTimeString
    else
      GetTime = dt.Now.ToShortTimeString
    end if
  end function
end class


