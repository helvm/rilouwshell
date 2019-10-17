\ RilouwShell 0.1.0
\ Copyright (c) 2019 Jerome Martin
\ Released under the terms of the GNU GPL version 3
\ http://rilouw.eu/project/rilouwshell

0 value quit?
0 value focused-element

variable mouse-x
variable mouse-y

create tmp-event sdl-event% %allot drop

: focused? ( element -- )  focused-element = ;
: update-focus ( -- )
  0 to focused-element
  page-pointer 0 do
    PAGE i cells + 2@
    over -rot \ keep element
    get-element-rect
    mouse-x @ mouse-y @ point-in-rect? if
      ( element ) to focused-element unloop exit
    else drop then
  2 +loop
;

: process-input ( -- )
  begin
    tmp-event sdl-poll-event \ while there is an event
  while
    tmp-event sdl-event-type c@
    case
      SDL_KEYDOWN of 
        tmp-event sdl-event-key sdl-keysym-sym uw@
        case
          SDLK_ESCAPE of true to quit? endof
          SDLK_q      of true to quit? endof
        endcase
      endof

      SDL_MOUSEMOTION of
        mouse-x mouse-y sdl-get-mouse-state drop
        update-focus
      endof
    endcase
  repeat
;
