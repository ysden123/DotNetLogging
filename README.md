# DotNetLogging
Playing with some logging packets for projects on C#.

## PNLog
Examples of using the NLog package.

## PSerilog
Examples of using the Serilog package.

## PSerilogWOInit
Examples of using the Serilog package without the logger initialization. The SilentLogger will be used and no output will be performed.

This refers to situations where you call Log.Information(), Log.Warning(), etc., without first setting Log.Logger = new LoggerConfiguration().CreateLogger();

Serilog is designed to be robust. If Log.Logger hasn't been explicitly configured, it falls back to a default "no-op" logger.

The default "no-op" logger that Serilog uses when it hasn't been initialized is indeed called SilentLogger.

As its name implies, SilentLogger does not write any logs to any sink (console, file, etc.). It effectively swallows all log events.

Why this behavior exists and why it's useful:
<ul>
	<li>
		Robustness in Libraries: If you're building a library that uses Serilog for its internal logging, you don't want to force the consuming application to configure Serilog. If they don't configure it, your library's logging will simply be silent, without causing errors or unexpected output.
	</li>
	<li>
		Early Application Startup: Sometimes, you might have code that runs very early in your application's lifecycle, even before your main Serilog configuration is set up. In such cases, if you attempt to log, Serilog will gracefully use the SilentLogger until the full configuration is in place.
	</li>
	<li>
		Testing: In unit tests, you often don't want your tests to produce actual log output. If your code uses Log.Information() directly and you don't initialize Serilog in your tests, it will use SilentLogger, keeping your test output clean.
	</li>
</ul>