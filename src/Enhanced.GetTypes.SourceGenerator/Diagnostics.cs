namespace Enhanced.GetTypes.SourceGenerator;

internal static class Diagnostics
{
    public static readonly DiagnosticDescriptor UnexpectedError = new DiagnosticDescriptor(
        "EGT001",
        "Unexpected Error",
        "An unexpected error occurred: {0}",
        "Unknown",
        DiagnosticSeverity.Error,
        true);

    public static readonly DiagnosticDescriptor MethodNotPartial = new DiagnosticDescriptor(
        "EGT101",
        "Method Not Partial",
        "Method must be declared as partial",
        "Schema",
        DiagnosticSeverity.Error,
        true);

    public static readonly DiagnosticDescriptor MethodHasParameters = new DiagnosticDescriptor(
        "EGT102",
        "Method Has Parameters",
        "Method must not have parameters",
        "Schema",
        DiagnosticSeverity.Error,
        true);

    public static readonly DiagnosticDescriptor MethodReturnTypeInvalid = new DiagnosticDescriptor(
        "EGT103",
        "Method Return Type Invalid",
        @"Method must return IEnumerable of Type",
        "Schema",
        DiagnosticSeverity.Error,
        true);

    public static Diagnostic ToDiagnostic(this DiagnosticDescriptor descriptor, Location? location,
        params object[] messageArgs) =>
        Diagnostic.Create(descriptor, location, messageArgs);
}
