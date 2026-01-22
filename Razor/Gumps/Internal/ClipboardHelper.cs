#region license

// Razor: An Ultima Online Assistant
// Copyright (c) 2026 DemonRok (modifica personalizzata)
// Basato su Razor originale: https://github.com/markdwags/Razor
//
// Questa modifica è distribuita con licenza GNU GPL v3.

#endregion

using System.Threading;
using System.Windows.Forms;

namespace Assistant
{
    /// <summary>
    /// Helper per operazioni sugli Appunti compatibili con thread non-STA (es. .NET naot).
    /// </summary>
    public static class ClipboardHelper
    {
        /// <summary>
        /// Imposta il testo negli Appunti di Windows, anche se chiamato da un thread MTA.
        /// </summary>
        /// <param name="text">Testo da copiare</param>
        public static void SetText(string text)
        {
            if (Thread.CurrentThread.GetApartmentState() == ApartmentState.STA)
            {
                Clipboard.SetText(text);
            }
            else
            {
                // Esegui su un thread STA dedicato
                var thread = new Thread(() =>
                {
                    Clipboard.SetText(text);
                });
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
                thread.Join(); // attendi il completamento
            }
        }
    }
}