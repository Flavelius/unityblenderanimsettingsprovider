Newer unity versions changed the way .blend files with animations automatically import by default (to the worse). Now they import as single scene clip, ignoring any custom created actions.
This silently broke imports for the usual way of structuring character animations.
This plugin allows patching the importer script to use either of the options to import them (as scene / by action)
and optionally auto-apply the fix/setting for team shared projects or when updating unity versions.
