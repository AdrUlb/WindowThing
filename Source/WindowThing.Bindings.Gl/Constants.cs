using GLbitfield = System.UInt32;
using GLenum = System.UInt32;

namespace RenderThing.Bindings.Gl;

public static class Constants
{
	public const GLbitfield GL_DEPTH_BUFFER_BIT = 0x100;
	public const GLbitfield GL_STENCIL_BUFFER_BIT = 0x400;
	public const GLbitfield GL_COLOR_BUFFER_BIT = 0x4000;

	public const GLenum GL_ZERO = 0x0;
	public const GLenum GL_ONE = 0x1;
	
	public const GLenum GL_POINTS = 0x0;
	public const GLenum GL_LINES = 0x1;
	public const GLenum GL_LINE_LOOP = 0x2;
	public const GLenum GL_LINE_STRIP = 0x3;
	public const GLenum GL_TRIANGLES = 0x4;
	public const GLenum GL_TRIANGLE_STRIP = 0x5;
	public const GLenum GL_TRIANGLE_FAN = 0x6;

	public const GLenum GL_SRC_COLOR = 0x300;
	public const GLenum GL_ONE_MINUS_SRC_COLOR = 0x301;
	public const GLenum GL_SRC_ALPHA = 0x302;
	public const GLenum GL_ONE_MINUS_SRC_ALPHA = 0x303;
	public const GLenum GL_DST_ALPHA = 0x304;
	public const GLenum GL_ONE_MINUS_DST_ALPHA = 0x305;
	public const GLenum GL_DST_COLOR = 0x306;
	public const GLenum GL_ONE_MINUS_DST_COLOR = 0x307;
	public const GLenum GL_SRC_ALPHA_SATURATE = 0x308;
	
	public const GLenum GL_CULL_FACE = 0xB44;
	
	public const GLenum GL_DEPTH_TEST = 0xB71;
	
	public const GLenum GL_STENCIL_TEST = 0xB90;
	
	public const GLenum GL_DITHER = 0xBD0;
	
	public const GLenum GL_BLEND = 0xBE2;
	
	public const GLenum GL_SCISSOR_TEST = 0xC11;
	
	public const GLenum GL_TEXTURE_2D = 0xDE1;

	public const GLenum GL_BYTE = 0x1400;
	public const GLenum GL_UNSIGNED_BYTE = 0x1401;
	public const GLenum GL_SHORT = 0x1402;
	public const GLenum GL_UNSIGNED_SHORT = 0x1403;
	public const GLenum GL_INT = 0x1404;
	public const GLenum GL_UNSIGNED_INT = 0x1405;
	public const GLenum GL_FLOAT = 0x1406;

	public const GLenum GL_HALF_FLOAT = 0x140B;
	public const GLenum GL_FIXED = 0x140C;

	public const GLenum GL_DEPTH_COMPONENT = 0x1902;
	public const GLenum GL_RED = 0x1903;

	public const GLenum GL_ALPHA = 0x1906;
	public const GLenum GL_RGB = 0x1907;
	public const GLenum GL_RGBA = 0x1908;
	public const GLenum GL_LUMINANCE = 0x1909;
	public const GLenum GL_LUMINANCE_ALPHA = 0x190A;

	public const GLenum GL_VENDOR = 0x1F00;
	public const GLenum GL_RENDERER = 0x1F01;
	public const GLenum GL_VERSION = 0x1F02;
	public const GLenum GL_EXTENSIONS = 0x1F03;
	
	public const GLenum GL_NEAREST = 0x2600;
	public const GLenum GL_LINEAR = 0x2601;

	public const GLenum GL_NEAREST_MIPMAP_NEAREST = 0x2700;
	public const GLenum GL_LINEAR_MIPMAP_NEAREST = 0x2701;
	public const GLenum GL_NEAREST_MIPMAP_LINEAR = 0x2702;
	public const GLenum GL_LINEAR_MIPMAP_LINEAR = 0x2703;

	public const GLenum GL_TEXTURE_MAG_FILTER = 0x2800;
	public const GLenum GL_TEXTURE_MIN_FILTER = 0x2801;
	public const GLenum GL_TEXTURE_WRAP_S = 0x2802;
	public const GLenum GL_TEXTURE_WRAP_T = 0x2803;

	public const GLenum GL_REPEAT = 0x2901;

	public const GLenum GL_CONSTANT_COLOR = 0x8001;
	public const GLenum GL_ONE_MINUS_CONSTANT_COLOR = 0x8002;
	public const GLenum GL_CONSTANT_ALPHA = 0x8003;
	public const GLenum GL_ONE_MINUS_CONSTANT_ALPHA = 0x8004;
	
	public const GLenum GL_UNSIGNED_SHORT_4_4_4_4 = 0x8033;
	public const GLenum GL_UNSIGNED_SHORT_5_5_5_1 = 0x8034;

	public const GLenum GL_POLYGON_OFFSET_FILL = 0x8037;
	
	public const GLenum GL_TEXTURE_3D = 0x806F;
	
	public const GLenum GL_TEXTURE_WRAP_R = 0x8072;
	
	public const GLenum GL_SAMPLE_ALPHA_TO_COVERAGE = 0x809E;
	
	public const GLenum GL_SAMPLE_COVERAGE = 0x80A0;
	
	public const GLenum GL_CLAMP_TO_EDGE = 0x812F;

	public const GLenum GL_TEXTURE_MIN_LOD = 0x813A;
	public const GLenum GL_TEXTURE_MAX_LOD = 0x813B;
	public const GLenum GL_TEXTURE_BASE_LEVEL = 0x813C;
	public const GLenum GL_TEXTURE_MAX_LEVEL = 0x813D;

	public const GLenum GL_RG = 0x8227;
	public const GLenum GL_RG_INTEGER = 0x8228;

	public const GLenum GL_PROGRAM_BINARY_RETRIEVABLE_HINT = 0x8257;
	public const GLenum GL_PROGRAM_SEPARABLE = 0x8258;

	public const GLenum GL_COMPUTE_WORK_GROUP_SIZE = 0x8267;

	public const GLenum GL_UNSIGNED_SHORT_5_6_5 = 0x8363;

	public const GLenum GL_UNSIGNED_INT_2_10_10_10_REV = 0x8368;

	public const GLenum GL_MIRRORED_REPEAT = 0x8370;

	public const GLenum GL_TEXTURE0 = 0x84C0;

	public const GLenum GL_DEPTH_STENCIL = 0x84F9;
	public const GLenum GL_UNSIGNED_INT_24_8 = 0x84FA;

	public const GLenum GL_TEXTURE_CUBE_MAP = 0x8513;

	public const GLenum GL_TEXTURE_COMPARE_FUNC = 0x884D;
	public const GLenum GL_TEXTURE_COMPARE_MODE = 0x884C;

	public const GLenum GL_MAX_TEXTURE_IMAGE_UNITS = 0x8872;

	public const GLenum GL_ARRAY_BUFFER = 0x8892;
	public const GLenum GL_ELEMENT_ARRAY_BUFFER = 0x8893;

	public const GLenum GL_STREAM_DRAW = 0x88E0;
	public const GLenum GL_STREAM_READ = 0x88E1;
	public const GLenum GL_STREAM_COPY = 0x88E2;

	public const GLenum GL_STATIC_DRAW = 0x88E4;
	public const GLenum GL_STATIC_READ = 0x88E5;
	public const GLenum GL_STATIC_COPY = 0x88E6;

	public const GLenum GL_DYNAMIC_DRAW = 0x88E8;
	public const GLenum GL_DYNAMIC_READ = 0x88E9;
	public const GLenum GL_DYNAMIC_COPY = 0x88EA;
	public const GLenum GL_PIXEL_PACK_BUFFER = 0x88EB;
	public const GLenum GL_PIXEL_UNPACK_BUFFER = 0x88EC;

	public const GLenum GL_UNIFORM_BUFFER = 0x8A11;

	public const GLenum GL_ACTIVE_UNIFORM_BLOCK_MAX_NAME_LENGTH = 0x8A35;
	public const GLenum GL_ACTIVE_UNIFORM_BLOCKS = 0x8A36;

	public const GLenum GL_FRAGMENT_SHADER = 0x8B30;
	public const GLenum GL_VERTEX_SHADER = 0x8B31;

	public const GLenum GL_SHADER_TYPE = 0x8B4F;

	public const GLenum GL_DELETE_STATUS = 0x8B80;
	public const GLenum GL_COMPILE_STATUS = 0x8B81;
	public const GLenum GL_LINK_STATUS = 0x8B82;
	public const GLenum GL_VALIDATE_STATUS = 0x8B83;
	public const GLenum GL_INFO_LOG_LENGTH = 0x8B84;
	public const GLenum GL_ATTACHED_SHADERS = 0x8B85;
	public const GLenum GL_ACTIVE_UNIFORMS = 0x8B86;
	public const GLenum GL_ACTIVE_UNIFORM_MAX_LENGTH = 0x8B87;
	public const GLenum GL_SHADER_SOURCE_LENGTH = 0x8B88;
	public const GLenum GL_ACTIVE_ATTRIBUTES = 0x8B89;
	public const GLenum GL_ACTIVE_ATTRIBUTE_MAX_LENGTH = 0x8B8A;

	public const GLenum GL_SHADING_LANGUAGE_VERSION = 0x8B8C;

	public const GLenum GL_TEXTURE_2D_ARRAY = 0x8C1A;

	public const GLenum GL_UNSIGNED_INT_10F_11F_11F_REV = 0x8C3B;

	public const GLenum GL_UNSIGNED_INT_5_9_9_9_REV = 0x8C3E;

	public const GLenum GL_TRANSFORM_FEEDBACK_VARYING_MAX_LENGTH = 0x8C76;
	public const GLenum GL_TRANSFORM_FEEDBACK_BUFFER_MODE = 0x8C7F;
	public const GLenum GL_TRANSFORM_FEEDBACK_VARYINGS = 0x8C83;

	public const GLenum GL_RASTERIZER_DISCARD = 0x8C89;
	
	public const GLenum GL_TRANSFORM_FEEDBACK_BUFFER = 0x8C8E;

	public const GLenum GL_PRIMITIVE_RESTART_FIXED_INDEX = 0x8D69;
	
	public const GLenum GL_RED_INTEGER = 0x8D94;

	public const GLenum GL_RGB_INTEGER = 0x8D98;
	public const GLenum GL_RGBA_INTEGER = 0x8D99;

	public const GLenum GL_INT_2_10_10_10_REV = 0x8D9F;

	public const GLenum GL_FLOAT_32_UNSIGNED_INT_24_8_REV = 0x8DAD;

	public const GLenum GL_TEXTURE_SWIZZLE_R = 0x8E42;
	public const GLenum GL_TEXTURE_SWIZZLE_G = 0x8E43;
	public const GLenum GL_TEXTURE_SWIZZLE_B = 0x8E44;
	public const GLenum GL_TEXTURE_SWIZZLE_A = 0x8E45;

	public const GLenum GL_SAMPLE_MASK = 0x8E51;

	public const GLenum GL_COPY_READ_BUFFER = 0x8F36;
	public const GLenum GL_COPY_WRITE_BUFFER = 0x8F37;

	public const GLenum GL_DRAW_INDIRECT_BUFFER = 0x8F3F;

	public const GLenum GL_SHADER_STORAGE_BUFFER = 0x90D2;

	public const GLenum GL_DISPATCH_INDIRECT_BUFFER = 0x90EE;

	public const GLenum GL_TEXTURE_2D_MULTISAMPLE = 0x9100;

	public const GLenum GL_COMPUTE_SHADER = 0x91B9;

	public const GLenum GL_ATOMIC_COUNTER_BUFFER = 0x92C0;

	public const GLenum GL_ACTIVE_ATOMIC_COUNTER_BUFFERS = 0x92D9;

	public const GLenum GL_DEPTH_STENCIL_TEXTURE_MODE = 0x90EA;
}
