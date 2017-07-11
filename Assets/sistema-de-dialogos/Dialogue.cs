using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class Dialogue {
    public List<Statement> statement;
    public int current;
    public bool readen; // thou shall not question my ancient grammar!

    public Statement CurrentStatement {
        get {
            try {
                return statement[current];
            } catch {
                return null;
            }
        }
    }

    public void Next () {
        // current goes from -1 to statement.Count-1
        // -1 means that the statement hasn't started or has finished.
        current = (current + 2) % (statement.Count + 1) - 1;

        if (current  == statement.Count-1) {
            readen = true;
        }
    }

    public bool HasNext () {
        return current != statement.Count-1;
    }

    public void Cancel () {
        current = -1;
    }

    public void Reset () {
        current = -1;
        readen = false;
    }
}
