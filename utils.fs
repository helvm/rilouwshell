\ RilouwShell 0.1.0
\ Copyright (c) 2019 Jerome Martin
\ Released under the terms of the GNU GPL version 3
\ http://rilouw.eu/project/rilouwshell

: log ( x -- x ) dup . cr ;
: terminate-str ( str len -- str ) over + 1- 0 swap c! ;
: ?error ( f str len -- )  rot if type cr bye else 2drop then ;

: point-in-rect? { xr yr wr hr x y -- b }
  x xr >
  x xr wr + < and
  y yr >
  y yr hr + < and
  and
;
