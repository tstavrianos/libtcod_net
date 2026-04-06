using static SDL3.SDL;

namespace SampleTCOD;

/// <summary>
/// Routes SDL events to overridable typed handler methods.
/// </summary>
/// <remarks>Based on the event dispatcher in python-tcod, but expanded to cover all SDL events.</remarks>
/// <typeparam name="T">The optional value returned by handlers.</typeparam>
public class EventDispatcher<T>
    where T : notnull
{
    /// <summary>
    /// Dispatches an SDL event to its matching protected handler.
    /// </summary>
    /// <param name="event">The SDL event union to route.</param>
    /// <returns>The handler result, or <see langword="null"/> when unhandled.</returns>
    public T? Dispatch(SDL_Event @event)
    {
        var type = (SDL_EventType)@event.type;

        return type switch
        {
            SDL_EventType.SDL_EVENT_QUIT => OnQuit(@event.quit),

            SDL_EventType.SDL_EVENT_TERMINATING
            or SDL_EventType.SDL_EVENT_LOW_MEMORY
            or SDL_EventType.SDL_EVENT_WILL_ENTER_BACKGROUND
            or SDL_EventType.SDL_EVENT_DID_ENTER_BACKGROUND
            or SDL_EventType.SDL_EVENT_WILL_ENTER_FOREGROUND
            or SDL_EventType.SDL_EVENT_DID_ENTER_FOREGROUND
            or SDL_EventType.SDL_EVENT_LOCALE_CHANGED
            or SDL_EventType.SDL_EVENT_SYSTEM_THEME_CHANGED
            or SDL_EventType.SDL_EVENT_JOYSTICK_UPDATE_COMPLETE
            or SDL_EventType.SDL_EVENT_GAMEPAD_UPDATE_COMPLETE
            or SDL_EventType.SDL_EVENT_PRIVATE0
            or SDL_EventType.SDL_EVENT_PRIVATE1
            or SDL_EventType.SDL_EVENT_PRIVATE2
            or SDL_EventType.SDL_EVENT_PRIVATE3
            or SDL_EventType.SDL_EVENT_POLL_SENTINEL => DispatchCommon(type, @event.common),

            SDL_EventType.SDL_EVENT_DISPLAY_ORIENTATION
            or SDL_EventType.SDL_EVENT_DISPLAY_ADDED
            or SDL_EventType.SDL_EVENT_DISPLAY_REMOVED
            or SDL_EventType.SDL_EVENT_DISPLAY_MOVED
            or SDL_EventType.SDL_EVENT_DISPLAY_DESKTOP_MODE_CHANGED
            or SDL_EventType.SDL_EVENT_DISPLAY_CURRENT_MODE_CHANGED
            or SDL_EventType.SDL_EVENT_DISPLAY_CONTENT_SCALE_CHANGED
            or SDL_EventType.SDL_EVENT_DISPLAY_USABLE_BOUNDS_CHANGED => DispatchDisplay(
                type,
                @event.display
            ),

            SDL_EventType.SDL_EVENT_WINDOW_SHOWN
            or SDL_EventType.SDL_EVENT_WINDOW_HIDDEN
            or SDL_EventType.SDL_EVENT_WINDOW_EXPOSED
            or SDL_EventType.SDL_EVENT_WINDOW_MOVED
            or SDL_EventType.SDL_EVENT_WINDOW_RESIZED
            or SDL_EventType.SDL_EVENT_WINDOW_PIXEL_SIZE_CHANGED
            or SDL_EventType.SDL_EVENT_WINDOW_METAL_VIEW_RESIZED
            or SDL_EventType.SDL_EVENT_WINDOW_MINIMIZED
            or SDL_EventType.SDL_EVENT_WINDOW_MAXIMIZED
            or SDL_EventType.SDL_EVENT_WINDOW_RESTORED
            or SDL_EventType.SDL_EVENT_WINDOW_MOUSE_ENTER
            or SDL_EventType.SDL_EVENT_WINDOW_MOUSE_LEAVE
            or SDL_EventType.SDL_EVENT_WINDOW_FOCUS_GAINED
            or SDL_EventType.SDL_EVENT_WINDOW_FOCUS_LOST
            or SDL_EventType.SDL_EVENT_WINDOW_CLOSE_REQUESTED
            or SDL_EventType.SDL_EVENT_WINDOW_HIT_TEST
            or SDL_EventType.SDL_EVENT_WINDOW_ICCPROF_CHANGED
            or SDL_EventType.SDL_EVENT_WINDOW_DISPLAY_CHANGED
            or SDL_EventType.SDL_EVENT_WINDOW_DISPLAY_SCALE_CHANGED
            or SDL_EventType.SDL_EVENT_WINDOW_SAFE_AREA_CHANGED
            or SDL_EventType.SDL_EVENT_WINDOW_OCCLUDED
            or SDL_EventType.SDL_EVENT_WINDOW_ENTER_FULLSCREEN
            or SDL_EventType.SDL_EVENT_WINDOW_LEAVE_FULLSCREEN
            or SDL_EventType.SDL_EVENT_WINDOW_DESTROYED
            or SDL_EventType.SDL_EVENT_WINDOW_HDR_STATE_CHANGED => DispatchWindow(
                type,
                @event.window
            ),

            SDL_EventType.SDL_EVENT_KEY_DOWN
            or SDL_EventType.SDL_EVENT_KEY_UP
            or SDL_EventType.SDL_EVENT_TEXT_EDITING
            or SDL_EventType.SDL_EVENT_TEXT_INPUT
            or SDL_EventType.SDL_EVENT_KEYMAP_CHANGED
            or SDL_EventType.SDL_EVENT_KEYBOARD_ADDED
            or SDL_EventType.SDL_EVENT_KEYBOARD_REMOVED
            or SDL_EventType.SDL_EVENT_TEXT_EDITING_CANDIDATES
            or SDL_EventType.SDL_EVENT_SCREEN_KEYBOARD_SHOWN
            or SDL_EventType.SDL_EVENT_SCREEN_KEYBOARD_HIDDEN => DispatchKeyboard(type, @event),

            SDL_EventType.SDL_EVENT_MOUSE_MOTION
            or SDL_EventType.SDL_EVENT_MOUSE_BUTTON_DOWN
            or SDL_EventType.SDL_EVENT_MOUSE_BUTTON_UP
            or SDL_EventType.SDL_EVENT_MOUSE_WHEEL
            or SDL_EventType.SDL_EVENT_MOUSE_ADDED
            or SDL_EventType.SDL_EVENT_MOUSE_REMOVED => DispatchMouse(type, @event),

            SDL_EventType.SDL_EVENT_JOYSTICK_AXIS_MOTION
            or SDL_EventType.SDL_EVENT_JOYSTICK_BALL_MOTION
            or SDL_EventType.SDL_EVENT_JOYSTICK_HAT_MOTION
            or SDL_EventType.SDL_EVENT_JOYSTICK_BUTTON_DOWN
            or SDL_EventType.SDL_EVENT_JOYSTICK_BUTTON_UP
            or SDL_EventType.SDL_EVENT_JOYSTICK_ADDED
            or SDL_EventType.SDL_EVENT_JOYSTICK_REMOVED
            or SDL_EventType.SDL_EVENT_JOYSTICK_BATTERY_UPDATED => DispatchJoystick(type, @event),

            SDL_EventType.SDL_EVENT_GAMEPAD_AXIS_MOTION
            or SDL_EventType.SDL_EVENT_GAMEPAD_BUTTON_DOWN
            or SDL_EventType.SDL_EVENT_GAMEPAD_BUTTON_UP
            or SDL_EventType.SDL_EVENT_GAMEPAD_ADDED
            or SDL_EventType.SDL_EVENT_GAMEPAD_REMOVED
            or SDL_EventType.SDL_EVENT_GAMEPAD_REMAPPED
            or SDL_EventType.SDL_EVENT_GAMEPAD_TOUCHPAD_DOWN
            or SDL_EventType.SDL_EVENT_GAMEPAD_TOUCHPAD_MOTION
            or SDL_EventType.SDL_EVENT_GAMEPAD_TOUCHPAD_UP
            or SDL_EventType.SDL_EVENT_GAMEPAD_SENSOR_UPDATE
            or SDL_EventType.SDL_EVENT_GAMEPAD_STEAM_HANDLE_UPDATED => DispatchGamepad(
                type,
                @event
            ),

            SDL_EventType.SDL_EVENT_FINGER_DOWN
            or SDL_EventType.SDL_EVENT_FINGER_UP
            or SDL_EventType.SDL_EVENT_FINGER_MOTION
            or SDL_EventType.SDL_EVENT_FINGER_CANCELED => DispatchFinger(type, @event.tfinger),

            SDL_EventType.SDL_EVENT_PINCH_BEGIN
            or SDL_EventType.SDL_EVENT_PINCH_UPDATE
            or SDL_EventType.SDL_EVENT_PINCH_END => DispatchPinch(type, @event.pinch),

            SDL_EventType.SDL_EVENT_DROP_FILE
            or SDL_EventType.SDL_EVENT_DROP_TEXT
            or SDL_EventType.SDL_EVENT_DROP_BEGIN
            or SDL_EventType.SDL_EVENT_DROP_COMPLETE
            or SDL_EventType.SDL_EVENT_DROP_POSITION => DispatchDrop(type, @event.drop),

            SDL_EventType.SDL_EVENT_AUDIO_DEVICE_ADDED
            or SDL_EventType.SDL_EVENT_AUDIO_DEVICE_REMOVED
            or SDL_EventType.SDL_EVENT_AUDIO_DEVICE_FORMAT_CHANGED => DispatchAudio(
                type,
                @event.adevice
            ),

            SDL_EventType.SDL_EVENT_PEN_PROXIMITY_IN
            or SDL_EventType.SDL_EVENT_PEN_PROXIMITY_OUT
            or SDL_EventType.SDL_EVENT_PEN_DOWN
            or SDL_EventType.SDL_EVENT_PEN_UP
            or SDL_EventType.SDL_EVENT_PEN_BUTTON_DOWN
            or SDL_EventType.SDL_EVENT_PEN_BUTTON_UP
            or SDL_EventType.SDL_EVENT_PEN_MOTION
            or SDL_EventType.SDL_EVENT_PEN_AXIS => DispatchPen(type, @event),

            SDL_EventType.SDL_EVENT_CAMERA_DEVICE_ADDED
            or SDL_EventType.SDL_EVENT_CAMERA_DEVICE_REMOVED
            or SDL_EventType.SDL_EVENT_CAMERA_DEVICE_APPROVED
            or SDL_EventType.SDL_EVENT_CAMERA_DEVICE_DENIED => DispatchCamera(type, @event.cdevice),

            SDL_EventType.SDL_EVENT_RENDER_TARGETS_RESET
            or SDL_EventType.SDL_EVENT_RENDER_DEVICE_RESET
            or SDL_EventType.SDL_EVENT_RENDER_DEVICE_LOST => DispatchRender(type, @event.render),

            SDL_EventType.SDL_EVENT_CLIPBOARD_UPDATE => OnClipboardUpdate(@event.clipboard),
            SDL_EventType.SDL_EVENT_SENSOR_UPDATE => OnSensorUpdate(@event.sensor),
            SDL_EventType.SDL_EVENT_USER => OnUser(@event.user),

            _ => default,
        };
    }

    private T? DispatchCommon(SDL_EventType type, SDL_CommonEvent @event) =>
        type switch
        {
            SDL_EventType.SDL_EVENT_TERMINATING => OnTerminating(@event),
            SDL_EventType.SDL_EVENT_LOW_MEMORY => OnLowMemory(@event),
            SDL_EventType.SDL_EVENT_WILL_ENTER_BACKGROUND => OnWillEnterBackground(@event),
            SDL_EventType.SDL_EVENT_DID_ENTER_BACKGROUND => OnDidEnterBackground(@event),
            SDL_EventType.SDL_EVENT_WILL_ENTER_FOREGROUND => OnWillEnterForeground(@event),
            SDL_EventType.SDL_EVENT_DID_ENTER_FOREGROUND => OnDidEnterForeground(@event),
            SDL_EventType.SDL_EVENT_LOCALE_CHANGED => OnLocaleChanged(@event),
            SDL_EventType.SDL_EVENT_SYSTEM_THEME_CHANGED => OnSystemThemeChanged(@event),
            SDL_EventType.SDL_EVENT_JOYSTICK_UPDATE_COMPLETE => OnJoystickUpdateComplete(@event),
            SDL_EventType.SDL_EVENT_GAMEPAD_UPDATE_COMPLETE => OnGamepadUpdateComplete(@event),
            SDL_EventType.SDL_EVENT_PRIVATE0 => OnPrivate0(@event),
            SDL_EventType.SDL_EVENT_PRIVATE1 => OnPrivate1(@event),
            SDL_EventType.SDL_EVENT_PRIVATE2 => OnPrivate2(@event),
            SDL_EventType.SDL_EVENT_PRIVATE3 => OnPrivate3(@event),
            SDL_EventType.SDL_EVENT_POLL_SENTINEL => OnPollSentinel(@event),
            _ => default,
        };

    private T? DispatchDisplay(SDL_EventType type, SDL_DisplayEvent @event) =>
        type switch
        {
            SDL_EventType.SDL_EVENT_DISPLAY_ORIENTATION => OnDisplayOrientation(@event),
            SDL_EventType.SDL_EVENT_DISPLAY_ADDED => OnDisplayAdded(@event),
            SDL_EventType.SDL_EVENT_DISPLAY_REMOVED => OnDisplayRemoved(@event),
            SDL_EventType.SDL_EVENT_DISPLAY_MOVED => OnDisplayMoved(@event),
            SDL_EventType.SDL_EVENT_DISPLAY_DESKTOP_MODE_CHANGED => OnDisplayDesktopModeChanged(
                @event
            ),
            SDL_EventType.SDL_EVENT_DISPLAY_CURRENT_MODE_CHANGED => OnDisplayCurrentModeChanged(
                @event
            ),
            SDL_EventType.SDL_EVENT_DISPLAY_CONTENT_SCALE_CHANGED => OnDisplayContentScaleChanged(
                @event
            ),
            SDL_EventType.SDL_EVENT_DISPLAY_USABLE_BOUNDS_CHANGED => OnDisplayUsableBoundsChanged(
                @event
            ),
            _ => default,
        };

    private T? DispatchWindow(SDL_EventType type, SDL_WindowEvent @event) =>
        type switch
        {
            SDL_EventType.SDL_EVENT_WINDOW_SHOWN => OnWindowShown(@event),
            SDL_EventType.SDL_EVENT_WINDOW_HIDDEN => OnWindowHidden(@event),
            SDL_EventType.SDL_EVENT_WINDOW_EXPOSED => OnWindowExposed(@event),
            SDL_EventType.SDL_EVENT_WINDOW_MOVED => OnWindowMoved(@event),
            SDL_EventType.SDL_EVENT_WINDOW_RESIZED => OnWindowResized(@event),
            SDL_EventType.SDL_EVENT_WINDOW_PIXEL_SIZE_CHANGED => OnWindowPixelSizeChanged(@event),
            SDL_EventType.SDL_EVENT_WINDOW_METAL_VIEW_RESIZED => OnWindowMetalViewResized(@event),
            SDL_EventType.SDL_EVENT_WINDOW_MINIMIZED => OnWindowMinimized(@event),
            SDL_EventType.SDL_EVENT_WINDOW_MAXIMIZED => OnWindowMaximized(@event),
            SDL_EventType.SDL_EVENT_WINDOW_RESTORED => OnWindowRestored(@event),
            SDL_EventType.SDL_EVENT_WINDOW_MOUSE_ENTER => OnWindowEnter(@event),
            SDL_EventType.SDL_EVENT_WINDOW_MOUSE_LEAVE => OnWindowLeave(@event),
            SDL_EventType.SDL_EVENT_WINDOW_FOCUS_GAINED => OnWindowFocusGained(@event),
            SDL_EventType.SDL_EVENT_WINDOW_FOCUS_LOST => OnWindowFocusLost(@event),
            SDL_EventType.SDL_EVENT_WINDOW_CLOSE_REQUESTED => OnWindowClose(@event),
            SDL_EventType.SDL_EVENT_WINDOW_HIT_TEST => OnWindowHitTest(@event),
            SDL_EventType.SDL_EVENT_WINDOW_ICCPROF_CHANGED => OnWindowIccProfileChanged(@event),
            SDL_EventType.SDL_EVENT_WINDOW_DISPLAY_CHANGED => OnWindowDisplayChanged(@event),
            SDL_EventType.SDL_EVENT_WINDOW_DISPLAY_SCALE_CHANGED => OnWindowDisplayScaleChanged(
                @event
            ),
            SDL_EventType.SDL_EVENT_WINDOW_SAFE_AREA_CHANGED => OnWindowSafeAreaChanged(@event),
            SDL_EventType.SDL_EVENT_WINDOW_OCCLUDED => OnWindowOccluded(@event),
            SDL_EventType.SDL_EVENT_WINDOW_ENTER_FULLSCREEN => OnWindowEnterFullscreen(@event),
            SDL_EventType.SDL_EVENT_WINDOW_LEAVE_FULLSCREEN => OnWindowLeaveFullscreen(@event),
            SDL_EventType.SDL_EVENT_WINDOW_DESTROYED => OnWindowDestroyed(@event),
            SDL_EventType.SDL_EVENT_WINDOW_HDR_STATE_CHANGED => OnWindowHdrStateChanged(@event),
            _ => default,
        };

    private T? DispatchKeyboard(SDL_EventType type, SDL_Event @event) =>
        type switch
        {
            SDL_EventType.SDL_EVENT_KEY_DOWN => OnKeyDown(@event.key),
            SDL_EventType.SDL_EVENT_KEY_UP => OnKeyUp(@event.key),
            SDL_EventType.SDL_EVENT_TEXT_EDITING => OnTextEditing(@event.edit),
            SDL_EventType.SDL_EVENT_TEXT_INPUT => OnTextInput(@event.text),
            SDL_EventType.SDL_EVENT_KEYMAP_CHANGED => OnKeymapChanged(@event.common),
            SDL_EventType.SDL_EVENT_KEYBOARD_ADDED => OnKeyboardAdded(@event.kdevice),
            SDL_EventType.SDL_EVENT_KEYBOARD_REMOVED => OnKeyboardRemoved(@event.kdevice),
            SDL_EventType.SDL_EVENT_TEXT_EDITING_CANDIDATES => OnTextEditingCandidates(
                @event.edit_candidates
            ),
            SDL_EventType.SDL_EVENT_SCREEN_KEYBOARD_SHOWN => OnScreenKeyboardShown(@event.common),
            SDL_EventType.SDL_EVENT_SCREEN_KEYBOARD_HIDDEN => OnScreenKeyboardHidden(@event.common),
            _ => default,
        };

    private T? DispatchMouse(SDL_EventType type, SDL_Event @event) =>
        type switch
        {
            SDL_EventType.SDL_EVENT_MOUSE_MOTION => OnMouseMotion(@event.motion),
            SDL_EventType.SDL_EVENT_MOUSE_BUTTON_DOWN => OnMouseButtonDown(@event.button),
            SDL_EventType.SDL_EVENT_MOUSE_BUTTON_UP => OnMouseButtonUp(@event.button),
            SDL_EventType.SDL_EVENT_MOUSE_WHEEL => OnMouseWheel(@event.wheel),
            SDL_EventType.SDL_EVENT_MOUSE_ADDED => OnMouseAdded(@event.mdevice),
            SDL_EventType.SDL_EVENT_MOUSE_REMOVED => OnMouseRemoved(@event.mdevice),
            _ => default,
        };

    private T? DispatchJoystick(SDL_EventType type, SDL_Event @event) =>
        type switch
        {
            SDL_EventType.SDL_EVENT_JOYSTICK_AXIS_MOTION => OnJoystickAxisMotion(@event.jaxis),
            SDL_EventType.SDL_EVENT_JOYSTICK_BALL_MOTION => OnJoystickBallMotion(@event.jball),
            SDL_EventType.SDL_EVENT_JOYSTICK_HAT_MOTION => OnJoystickHatMotion(@event.jhat),
            SDL_EventType.SDL_EVENT_JOYSTICK_BUTTON_DOWN => OnJoystickButtonDown(@event.jbutton),
            SDL_EventType.SDL_EVENT_JOYSTICK_BUTTON_UP => OnJoystickButtonUp(@event.jbutton),
            SDL_EventType.SDL_EVENT_JOYSTICK_ADDED => OnJoystickDeviceAdded(@event.jdevice),
            SDL_EventType.SDL_EVENT_JOYSTICK_REMOVED => OnJoystickDeviceRemoved(@event.jdevice),
            SDL_EventType.SDL_EVENT_JOYSTICK_BATTERY_UPDATED => OnJoystickBatteryUpdated(
                @event.jbattery
            ),
            _ => default,
        };

    private T? DispatchGamepad(SDL_EventType type, SDL_Event @event) =>
        type switch
        {
            SDL_EventType.SDL_EVENT_GAMEPAD_AXIS_MOTION => OnGamepadAxisMotion(@event.gaxis),
            SDL_EventType.SDL_EVENT_GAMEPAD_BUTTON_DOWN => OnGamepadButtonDown(@event.gbutton),
            SDL_EventType.SDL_EVENT_GAMEPAD_BUTTON_UP => OnGamepadButtonUp(@event.gbutton),
            SDL_EventType.SDL_EVENT_GAMEPAD_ADDED => OnGamepadDeviceAdded(@event.gdevice),
            SDL_EventType.SDL_EVENT_GAMEPAD_REMOVED => OnGamepadDeviceRemoved(@event.gdevice),
            SDL_EventType.SDL_EVENT_GAMEPAD_REMAPPED => OnGamepadDeviceRemapped(@event.gdevice),
            SDL_EventType.SDL_EVENT_GAMEPAD_TOUCHPAD_DOWN => OnGamepadTouchpadDown(
                @event.gtouchpad
            ),
            SDL_EventType.SDL_EVENT_GAMEPAD_TOUCHPAD_MOTION => OnGamepadTouchpadMotion(
                @event.gtouchpad
            ),
            SDL_EventType.SDL_EVENT_GAMEPAD_TOUCHPAD_UP => OnGamepadTouchpadUp(@event.gtouchpad),
            SDL_EventType.SDL_EVENT_GAMEPAD_SENSOR_UPDATE => OnGamepadSensorUpdate(@event.gsensor),
            SDL_EventType.SDL_EVENT_GAMEPAD_STEAM_HANDLE_UPDATED => OnGamepadSteamHandleUpdated(
                @event.gdevice
            ),
            _ => default,
        };

    private T? DispatchFinger(SDL_EventType type, SDL_TouchFingerEvent @event) =>
        type switch
        {
            SDL_EventType.SDL_EVENT_FINGER_DOWN => OnFingerDown(@event),
            SDL_EventType.SDL_EVENT_FINGER_UP => OnFingerUp(@event),
            SDL_EventType.SDL_EVENT_FINGER_MOTION => OnFingerMotion(@event),
            SDL_EventType.SDL_EVENT_FINGER_CANCELED => OnFingerCanceled(@event),
            _ => default,
        };

    private T? DispatchPinch(SDL_EventType type, SDL_PinchFingerEvent @event) =>
        type switch
        {
            SDL_EventType.SDL_EVENT_PINCH_BEGIN => OnPinchBegin(@event),
            SDL_EventType.SDL_EVENT_PINCH_UPDATE => OnPinchUpdate(@event),
            SDL_EventType.SDL_EVENT_PINCH_END => OnPinchEnd(@event),
            _ => default,
        };

    private T? DispatchDrop(SDL_EventType type, SDL_DropEvent @event) =>
        type switch
        {
            SDL_EventType.SDL_EVENT_DROP_FILE => OnDropFile(@event),
            SDL_EventType.SDL_EVENT_DROP_TEXT => OnDropText(@event),
            SDL_EventType.SDL_EVENT_DROP_BEGIN => OnDropBegin(@event),
            SDL_EventType.SDL_EVENT_DROP_COMPLETE => OnDropComplete(@event),
            SDL_EventType.SDL_EVENT_DROP_POSITION => OnDropPosition(@event),
            _ => default,
        };

    private T? DispatchAudio(SDL_EventType type, SDL_AudioDeviceEvent @event) =>
        type switch
        {
            SDL_EventType.SDL_EVENT_AUDIO_DEVICE_ADDED => OnAudioDeviceAdded(@event),
            SDL_EventType.SDL_EVENT_AUDIO_DEVICE_REMOVED => OnAudioDeviceRemoved(@event),
            SDL_EventType.SDL_EVENT_AUDIO_DEVICE_FORMAT_CHANGED => OnAudioDeviceFormatChanged(
                @event
            ),
            _ => default,
        };

    private T? DispatchPen(SDL_EventType type, SDL_Event @event) =>
        type switch
        {
            SDL_EventType.SDL_EVENT_PEN_PROXIMITY_IN => OnPenProximityIn(@event.pproximity),
            SDL_EventType.SDL_EVENT_PEN_PROXIMITY_OUT => OnPenProximityOut(@event.pproximity),
            SDL_EventType.SDL_EVENT_PEN_DOWN => OnPenDown(@event.ptouch),
            SDL_EventType.SDL_EVENT_PEN_UP => OnPenUp(@event.ptouch),
            SDL_EventType.SDL_EVENT_PEN_BUTTON_DOWN => OnPenButtonDown(@event.pbutton),
            SDL_EventType.SDL_EVENT_PEN_BUTTON_UP => OnPenButtonUp(@event.pbutton),
            SDL_EventType.SDL_EVENT_PEN_MOTION => OnPenMotion(@event.pmotion),
            SDL_EventType.SDL_EVENT_PEN_AXIS => OnPenAxis(@event.paxis),
            _ => default,
        };

    private T? DispatchCamera(SDL_EventType type, SDL_CameraDeviceEvent @event) =>
        type switch
        {
            SDL_EventType.SDL_EVENT_CAMERA_DEVICE_ADDED => OnCameraDeviceAdded(@event),
            SDL_EventType.SDL_EVENT_CAMERA_DEVICE_REMOVED => OnCameraDeviceRemoved(@event),
            SDL_EventType.SDL_EVENT_CAMERA_DEVICE_APPROVED => OnCameraDeviceApproved(@event),
            SDL_EventType.SDL_EVENT_CAMERA_DEVICE_DENIED => OnCameraDeviceDenied(@event),
            _ => default,
        };

    private T? DispatchRender(SDL_EventType type, SDL_RenderEvent @event) =>
        type switch
        {
            SDL_EventType.SDL_EVENT_RENDER_TARGETS_RESET => OnRenderTargetsReset(@event),
            SDL_EventType.SDL_EVENT_RENDER_DEVICE_RESET => OnRenderDeviceReset(@event),
            SDL_EventType.SDL_EVENT_RENDER_DEVICE_LOST => OnRenderDeviceLost(@event),
            _ => default,
        };

    /// <summary>
    /// User-requested quit.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnQuit(SDL_QuitEvent @event) => default;

    /// <summary>
    /// The application is being terminated by the OS.
    /// On iOS and Android, this event must be handled from an event watch callback
    /// registered with <c>SDL_AddEventWatch()</c>.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnTerminating(SDL_CommonEvent @event) => default;

    /// <summary>
    /// The application is low on memory; free memory if possible.
    /// On iOS and Android, this event must be handled from an event watch callback
    /// registered with <c>SDL_AddEventWatch()</c>.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnLowMemory(SDL_CommonEvent @event) => default;

    /// <summary>
    /// The application is about to enter the background.
    /// On iOS and Android, this event must be handled from an event watch callback
    /// registered with <c>SDL_AddEventWatch()</c>.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnWillEnterBackground(SDL_CommonEvent @event) => default;

    /// <summary>
    /// The application did enter the background and may not get CPU for some time.
    /// On iOS and Android, this event must be handled from an event watch callback
    /// registered with <c>SDL_AddEventWatch()</c>.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnDidEnterBackground(SDL_CommonEvent @event) => default;

    /// <summary>
    /// The application is about to enter the foreground.
    /// On iOS and Android, this event must be handled from an event watch callback
    /// registered with <c>SDL_AddEventWatch()</c>.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnWillEnterForeground(SDL_CommonEvent @event) => default;

    /// <summary>
    /// The application is now interactive.
    /// On iOS and Android, this event must be handled from an event watch callback
    /// registered with <c>SDL_AddEventWatch()</c>.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnDidEnterForeground(SDL_CommonEvent @event) => default;

    /// <summary>
    /// The user's locale preferences have changed.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnLocaleChanged(SDL_CommonEvent @event) => default;

    /// <summary>
    /// The system theme changed.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnSystemThemeChanged(SDL_CommonEvent @event) => default;

    /// <summary>
    /// Display orientation has changed.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnDisplayOrientation(SDL_DisplayEvent @event) => default;

    /// <summary>
    /// Display has been added to the system.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnDisplayAdded(SDL_DisplayEvent @event) => default;

    /// <summary>
    /// Display has been removed from the system.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnDisplayRemoved(SDL_DisplayEvent @event) => default;

    /// <summary>
    /// Display has changed position.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnDisplayMoved(SDL_DisplayEvent @event) => default;

    /// <summary>
    /// Display has changed desktop mode.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnDisplayDesktopModeChanged(SDL_DisplayEvent @event) => default;

    /// <summary>
    /// Display has changed current mode.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnDisplayCurrentModeChanged(SDL_DisplayEvent @event) => default;

    /// <summary>
    /// Display has changed content scale.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnDisplayContentScaleChanged(SDL_DisplayEvent @event) => default;

    /// <summary>
    /// Display has changed usable bounds.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnDisplayUsableBoundsChanged(SDL_DisplayEvent @event) => default;

    /// <summary>
    /// Key pressed.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnKeyDown(SDL_KeyboardEvent @event) => default;

    /// <summary>
    /// Key released.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnKeyUp(SDL_KeyboardEvent @event) => default;

    /// <summary>
    /// Keyboard text editing (composition).
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnTextEditing(SDL_TextEditingEvent @event) => default;

    /// <summary>
    /// Keyboard text input.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnTextInput(SDL_TextInputEvent @event) => default;

    /// <summary>
    /// Keymap changed due to a system event such as an input language or keyboard layout change.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnKeymapChanged(SDL_CommonEvent @event) => default;

    /// <summary>
    /// A new keyboard has been inserted into the system.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnKeyboardAdded(SDL_KeyboardDeviceEvent @event) => default;

    /// <summary>
    /// A keyboard has been removed.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnKeyboardRemoved(SDL_KeyboardDeviceEvent @event) => default;

    /// <summary>
    /// Keyboard text editing candidates updated.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnTextEditingCandidates(SDL_TextEditingCandidatesEvent @event) => default;

    /// <summary>
    /// The on-screen keyboard has been shown.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnScreenKeyboardShown(SDL_CommonEvent @event) => default;

    /// <summary>
    /// The on-screen keyboard has been hidden.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnScreenKeyboardHidden(SDL_CommonEvent @event) => default;

    /// <summary>
    /// Mouse moved.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnMouseMotion(SDL_MouseMotionEvent @event) => default;

    /// <summary>
    /// Mouse button pressed.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnMouseButtonDown(SDL_MouseButtonEvent @event) => default;

    /// <summary>
    /// Mouse button released.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnMouseButtonUp(SDL_MouseButtonEvent @event) => default;

    /// <summary>
    /// Mouse wheel motion.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnMouseWheel(SDL_MouseWheelEvent @event) => default;

    /// <summary>
    /// A new mouse has been inserted into the system.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnMouseAdded(SDL_MouseDeviceEvent @event) => default;

    /// <summary>
    /// A mouse has been removed.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnMouseRemoved(SDL_MouseDeviceEvent @event) => default;

    /// <summary>
    /// Window has been shown.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnWindowShown(SDL_WindowEvent @event) => default;

    /// <summary>
    /// Window has been hidden.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnWindowHidden(SDL_WindowEvent @event) => default;

    /// <summary>
    /// Window has been exposed and should be redrawn.
    /// This can be redrawn directly from an event watch callback for this event.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnWindowExposed(SDL_WindowEvent @event) => default;

    /// <summary>
    /// Window has been moved.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnWindowMoved(SDL_WindowEvent @event) => default;

    /// <summary>
    /// Window has been resized.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnWindowResized(SDL_WindowEvent @event) => default;

    /// <summary>
    /// The pixel size of the window has changed.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnWindowPixelSizeChanged(SDL_WindowEvent @event) => default;

    /// <summary>
    /// The pixel size of a Metal view associated with the window has changed.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnWindowMetalViewResized(SDL_WindowEvent @event) => default;

    /// <summary>
    /// Window has been minimized.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnWindowMinimized(SDL_WindowEvent @event) => default;

    /// <summary>
    /// Window has been maximized.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnWindowMaximized(SDL_WindowEvent @event) => default;

    /// <summary>
    /// Window has been restored to normal size and position.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnWindowRestored(SDL_WindowEvent @event) => default;

    /// <summary>
    /// Window has gained mouse focus.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnWindowEnter(SDL_WindowEvent @event) => default;

    /// <summary>
    /// Window has lost mouse focus.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnWindowLeave(SDL_WindowEvent @event) => default;

    /// <summary>
    /// Window has gained keyboard focus.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnWindowFocusGained(SDL_WindowEvent @event) => default;

    /// <summary>
    /// Window has lost keyboard focus.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnWindowFocusLost(SDL_WindowEvent @event) => default;

    /// <summary>
    /// The window manager requests that the window be closed.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnWindowClose(SDL_WindowEvent @event) => default;

    /// <summary>
    /// Window had a hit test that was not SDL_HITTEST_NORMAL.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnWindowHitTest(SDL_WindowEvent @event) => default;

    /// <summary>
    /// The window's ICC profile has changed.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnWindowIccProfileChanged(SDL_WindowEvent @event) => default;

    /// <summary>
    /// Window has been moved to a different display.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnWindowDisplayChanged(SDL_WindowEvent @event) => default;

    /// <summary>
    /// Window display scale has been changed.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnWindowDisplayScaleChanged(SDL_WindowEvent @event) => default;

    /// <summary>
    /// The window safe area has been changed.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnWindowSafeAreaChanged(SDL_WindowEvent @event) => default;

    /// <summary>
    /// The window has been occluded.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnWindowOccluded(SDL_WindowEvent @event) => default;

    /// <summary>
    /// The window has entered fullscreen mode.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnWindowEnterFullscreen(SDL_WindowEvent @event) => default;

    /// <summary>
    /// The window has left fullscreen mode.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnWindowLeaveFullscreen(SDL_WindowEvent @event) => default;

    /// <summary>
    /// The window is being or has been destroyed.
    /// When handled in an event watch callback, the window handle is still valid;
    /// otherwise the handle has already been destroyed.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnWindowDestroyed(SDL_WindowEvent @event) => default;

    /// <summary>
    /// Window HDR properties have changed.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnWindowHdrStateChanged(SDL_WindowEvent @event) => default;

    /// <summary>
    /// Joystick axis motion.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnJoystickAxisMotion(SDL_JoyAxisEvent @event) => default;

    /// <summary>
    /// Joystick trackball motion.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnJoystickBallMotion(SDL_JoyBallEvent @event) => default;

    /// <summary>
    /// Joystick hat position change.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnJoystickHatMotion(SDL_JoyHatEvent @event) => default;

    /// <summary>
    /// Joystick button pressed.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnJoystickButtonDown(SDL_JoyButtonEvent @event) => default;

    /// <summary>
    /// Joystick button released.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnJoystickButtonUp(SDL_JoyButtonEvent @event) => default;

    /// <summary>
    /// A new joystick has been inserted into the system.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnJoystickDeviceAdded(SDL_JoyDeviceEvent @event) => default;

    /// <summary>
    /// An opened joystick has been removed.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnJoystickDeviceRemoved(SDL_JoyDeviceEvent @event) => default;

    /// <summary>
    /// Joystick battery level changed.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnJoystickBatteryUpdated(SDL_JoyBatteryEvent @event) => default;

    /// <summary>
    /// Joystick update is complete.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnJoystickUpdateComplete(SDL_CommonEvent @event) => default;

    /// <summary>
    /// Gamepad axis motion.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnGamepadAxisMotion(SDL_GamepadAxisEvent @event) => default;

    /// <summary>
    /// Gamepad button pressed.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnGamepadButtonDown(SDL_GamepadButtonEvent @event) => default;

    /// <summary>
    /// Gamepad button released.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnGamepadButtonUp(SDL_GamepadButtonEvent @event) => default;

    /// <summary>
    /// A new gamepad has been inserted into the system.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnGamepadDeviceAdded(SDL_GamepadDeviceEvent @event) => default;

    /// <summary>
    /// A gamepad has been removed.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnGamepadDeviceRemoved(SDL_GamepadDeviceEvent @event) => default;

    /// <summary>
    /// The gamepad mapping was updated.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnGamepadDeviceRemapped(SDL_GamepadDeviceEvent @event) => default;

    /// <summary>
    /// Gamepad touchpad was touched.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnGamepadTouchpadDown(SDL_GamepadTouchpadEvent @event) => default;

    /// <summary>
    /// Gamepad touchpad finger was moved.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnGamepadTouchpadMotion(SDL_GamepadTouchpadEvent @event) => default;

    /// <summary>
    /// Gamepad touchpad finger was lifted.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnGamepadTouchpadUp(SDL_GamepadTouchpadEvent @event) => default;

    /// <summary>
    /// Gamepad sensor was updated.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnGamepadSensorUpdate(SDL_GamepadSensorEvent @event) => default;

    /// <summary>
    /// Gamepad update is complete.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnGamepadUpdateComplete(SDL_CommonEvent @event) => default;

    /// <summary>
    /// Gamepad Steam handle has changed.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnGamepadSteamHandleUpdated(SDL_GamepadDeviceEvent @event) => default;

    /// <summary>
    /// A touch finger contact began.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnFingerDown(SDL_TouchFingerEvent @event) => default;

    /// <summary>
    /// A touch finger contact ended.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnFingerUp(SDL_TouchFingerEvent @event) => default;

    /// <summary>
    /// A touch finger moved.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnFingerMotion(SDL_TouchFingerEvent @event) => default;

    /// <summary>
    /// A touch finger was canceled.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnFingerCanceled(SDL_TouchFingerEvent @event) => default;

    /// <summary>
    /// Pinch gesture started.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnPinchBegin(SDL_PinchFingerEvent @event) => default;

    /// <summary>
    /// Pinch gesture updated.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnPinchUpdate(SDL_PinchFingerEvent @event) => default;

    /// <summary>
    /// Pinch gesture ended.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnPinchEnd(SDL_PinchFingerEvent @event) => default;

    /// <summary>
    /// The clipboard changed.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnClipboardUpdate(SDL_ClipboardEvent @event) => default;

    /// <summary>
    /// The system requests a file open.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnDropFile(SDL_DropEvent @event) => default;

    /// <summary>
    /// A text/plain drag-and-drop event was received.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnDropText(SDL_DropEvent @event) => default;

    /// <summary>
    /// A new set of drops is beginning.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnDropBegin(SDL_DropEvent @event) => default;

    /// <summary>
    /// The current set of drops is now complete.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnDropComplete(SDL_DropEvent @event) => default;

    /// <summary>
    /// Drag-and-drop position while moving over the window.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnDropPosition(SDL_DropEvent @event) => default;

    /// <summary>
    /// A new audio device is available.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnAudioDeviceAdded(SDL_AudioDeviceEvent @event) => default;

    /// <summary>
    /// An audio device has been removed.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnAudioDeviceRemoved(SDL_AudioDeviceEvent @event) => default;

    /// <summary>
    /// An audio device format has been changed by the system.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnAudioDeviceFormatChanged(SDL_AudioDeviceEvent @event) => default;

    /// <summary>
    /// A sensor was updated.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnSensorUpdate(SDL_SensorEvent @event) => default;

    /// <summary>
    /// A pressure-sensitive pen has become available.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnPenProximityIn(SDL_PenProximityEvent @event) => default;

    /// <summary>
    /// A pressure-sensitive pen has become unavailable.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnPenProximityOut(SDL_PenProximityEvent @event) => default;

    /// <summary>
    /// A pressure-sensitive pen touched the drawing surface.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnPenDown(SDL_PenTouchEvent @event) => default;

    /// <summary>
    /// A pressure-sensitive pen stopped touching the drawing surface.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnPenUp(SDL_PenTouchEvent @event) => default;

    /// <summary>
    /// A pressure-sensitive pen button was pressed.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnPenButtonDown(SDL_PenButtonEvent @event) => default;

    /// <summary>
    /// A pressure-sensitive pen button was released.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnPenButtonUp(SDL_PenButtonEvent @event) => default;

    /// <summary>
    /// A pressure-sensitive pen is moving on the tablet.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnPenMotion(SDL_PenMotionEvent @event) => default;

    /// <summary>
    /// A pressure-sensitive pen angle, pressure, or another axis changed.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnPenAxis(SDL_PenAxisEvent @event) => default;

    /// <summary>
    /// A new camera device is available.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnCameraDeviceAdded(SDL_CameraDeviceEvent @event) => default;

    /// <summary>
    /// A camera device has been removed.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnCameraDeviceRemoved(SDL_CameraDeviceEvent @event) => default;

    /// <summary>
    /// A camera device has been approved for use by the user.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnCameraDeviceApproved(SDL_CameraDeviceEvent @event) => default;

    /// <summary>
    /// A camera device has been denied for use by the user.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnCameraDeviceDenied(SDL_CameraDeviceEvent @event) => default;

    /// <summary>
    /// The render targets have been reset and their contents need to be updated.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnRenderTargetsReset(SDL_RenderEvent @event) => default;

    /// <summary>
    /// The render device has been reset and all textures need to be recreated.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnRenderDeviceReset(SDL_RenderEvent @event) => default;

    /// <summary>
    /// The render device has been lost and cannot be recovered.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnRenderDeviceLost(SDL_RenderEvent @event) => default;

    /// <summary>
    /// Reserved private platform event slot 0.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnPrivate0(SDL_CommonEvent @event) => default;

    /// <summary>
    /// Reserved private platform event slot 1.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnPrivate1(SDL_CommonEvent @event) => default;

    /// <summary>
    /// Reserved private platform event slot 2.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnPrivate2(SDL_CommonEvent @event) => default;

    /// <summary>
    /// Reserved private platform event slot 3.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnPrivate3(SDL_CommonEvent @event) => default;

    /// <summary>
    /// Signals the end of an event poll cycle.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnPollSentinel(SDL_CommonEvent @event) => default;

    /// <summary>
    /// User-defined event payload.
    /// </summary>
    /// <param name="event">The strongly typed SDL event payload.</param>
    /// <returns>A handler result, or <see langword="null"/> to ignore the event.</returns>
    protected virtual T? OnUser(SDL_UserEvent @event) => default;
}
