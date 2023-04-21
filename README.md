# A OmniRig COM wrapper for NET Framework


This is a NET Framework COM wrapper for Omnirig targeting NET Framework 4.8, in order to allow it to be used
with NET6/7.

NET 5 & up doesn't support COM references (interop references are probably better..) however AFAIK in order to interface with OmniRig
the easiest is just to use the legacy: `<COMReference Include="OmniRig">`

This lib simply exposes the OmniRigEngine and Rig instance, nothing more.
