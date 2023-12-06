Zunächst einmal möchte ich meine Dankbarkeit für die zugewiesene Aufgabe ausdrücken. Es war mir eine Freude, daran zu arbeiten, insbesondere weil es einige Herausforderungen im Hinblick auf das Unit Testing gab, bedingt durch die Einbindung einer Datenbank.

Nach meinen Bemühungen habe ich die unten aufgeführten Ergebnisse erzielt. Ich hoffe, mein Verständnis der Anforderungen ist korrekt. Ein Unit-Test ist ebenfalls verfügbar. Darüber hinaus habe ich die in dieser Datei verwendete Tabelle sowie einige Dokumentationen zum Code in Englisch hinzugefügt.

Was den zweiten Teil betrifft, in dem es um das Speichern von Daten ging, möchte ich darauf hinweisen, dass es alternative Methoden wie die Serialisierung gibt, die schneller und kostengünstiger sind. Diese Methode eignet sich gut für kleine Datensätze, ist jedoch weniger ideal für größere.

Auf der anderen Seite bieten Datenbanken und EF Core Vorteile für größere Datensätze und gewährleisten Datenkonsistenz. Dies geht jedoch mit Kosten und Komplexität einher, insbesondere für kleinere Projekte wie dieses. Es könnten Latenzprobleme auftreten, insbesondere bei Remote-Datenbankzugriff.

Vielen Dank für die Gelegenheit, an dieser Aufgabe zu arbeiten. Ich stehe für weitere Fragen oder Anpassungen zur Verfügung.



****** Neues Update.******



Ich habe einige Änderungen am Code vorgenommen, und obwohl das Unit-Testing ein wenig knifflig war, glaube ich, dass es jetzt gut laufen sollte. In Bezug auf die Entscheidung, sogar für ein kleines Projekt eine Datenbank zu verwenden, gibt es mehrere Gründe. Erstens wachsen Projekte oft im Laufe der Zeit, und ich möchte auf diese Expansion vorbereitet sein. Die Verwendung einer Datenbank ermöglicht Skalierbarkeit, und wenn Daten zunehmen oder Funktionen komplexer werden, können SQL-Abfragen sehr nützlich sein. Wenn ich sicher wäre, dass das Projekt einfach bleibt und kleine Datenmengen hat, würde ich wahrscheinlich Serialisierung verwenden, aber die Vorhersage zukünftiger Entwicklungen ist entscheidend und sollte während der Anforderungstechnik berücksichtigt werden.

Was die Frage betrifft, warum ich möchte, dass die Leute darüber informiert sind, dass der Code getestet wurde, geht es um Erwartungssetzung. Ich möchte, dass sie von Anfang an wissen, dass der Code sich während des Tests möglicherweise anders verhält. Wenn sie beispielsweise keine Aktualisierung in der Datenbank sehen, liegt das an den spezifischen Testbedingungen und nicht an einem Fehler im Code selbst.

