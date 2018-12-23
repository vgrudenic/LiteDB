﻿using LiteDB.Engine;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("LiteDB.Demo")]

namespace LiteDB
{
    /// <summary>
    /// Class with all constants used in LiteDB + Debbuger HELPER
    /// </summary>
    internal class Constants
    {
        /// <summary>
        /// The size of each page in disk - use 8192 as all major databases
        /// </summary>
        public const int PAGE_SIZE = 8192;

        /// <summary>
        /// Header page size
        /// </summary>
        public const int PAGE_HEADER_SIZE = 32;

        /// <summary>
        /// Bytes used in encryption salt
        /// </summary>
        public const int ENCRYPTION_SALT_SIZE = 16;

        /// <summary>
        /// Position in disk to write SALT bytes - 1 byte from second page (Page #1) - This page will store only this data - never ever change
        /// </summary>
        public const int P_ENCRYPTION_SALT = PAGE_SIZE;

        /// <summary>
        /// Define ShareCounter buffer as writable
        /// </summary>
        public static int BUFFER_WRITABLE = -1;

        /// <summary>
        /// Define index name max length
        /// </summary>
        public static int INDEX_NAME_MAX_LENGTH = 32;

        /// <summary>
        /// Max level used on skip list (index).
        /// </summary>
        public const int MAX_LEVEL_LENGTH = 32;

        /// <summary>
        /// Max size of a index entry - usde for string, binary, array and documents. Need fit in 1 byte length
        /// </summary>
        public const int MAX_INDEX_KEY_LENGTH = 255;

        /// <summary>
        /// Document limit size - must use max 250 pages [1 byte] => 250 * 8149 = ~2MiB
        /// </summary>
        public const int MAX_DOCUMENT_SIZE = 250 * (DataService.MAX_DATA_BYTES_PER_PAGE);

        /// <summary>
        /// Max pages in a transaction before persist on disk and clear transaction local pages
        /// </summary>
        public const int MAX_TRANSACTION_SIZE = 10000; // 10000 (default) - 1000 (for tests)

        /// <summary>
        /// Size, in PAGES, for each buffer array (used in MemoryStore) - Each byte array will be created with this size * PAGE_SIZE
        /// </summary>
        public const int MEMORY_SEGMENT_SIZE = 1000; // 8Mb per extend

        /// <summary>
        /// Minimum pages not in use to remove pages from _readable/_writable list to _free list
        /// </summary>
        public const int MINIMUM_CACHE_REUSE = 10000; // 10000 (default) - 1000 (for tests)

        /// <summary>
        /// Database header parameter: USERVERSION
        /// </summary>
        public const string DB_PARAM_USERVERSION = "USERVERSION";

        /// <summary>
        /// Log a message using Debug.WriteLine
        /// </summary>
        [DebuggerHidden]
        [Conditional("DEBUG")]
        public static void LOG(string message, string category)
        {
            Debug.WriteLine(message, category);
        }

        /// <summary>
        /// Ensure condition is true, otherwise stop execution (for Debug proposes only)
        /// </summary>
        [DebuggerHidden]
        [Conditional("DEBUG")]
        public static void ENSURE(bool conditional, string message = null)
        {
            if (conditional == false)
            {
                if (Debugger.IsAttached)
                {
                    Debug.Fail(message);
                }
                else
                {
                    throw new SystemException("ENSURE: " + message);
                }
            }
        }

        /// <summary>
        /// If ifTest are true, ensure condition is true, otherwise stop execution (for Debug proposes only)
        /// </summary>
        [DebuggerHidden]
        [Conditional("DEBUG")]
        public static void ENSURE(bool ifTest, bool conditional, string message = null)
        {
            if (ifTest && conditional == false)
            {
                if (Debugger.IsAttached)
                {
                    Debug.Fail(message);
                }
                else
                {
                    throw new SystemException("ENSURE: " + message);
                }
            }
        }
    }
}
